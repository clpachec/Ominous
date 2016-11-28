using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float maxSpeed = 9f;
    public float darkness = 0.8f;
    public bool disableFlashLight = false;
    public string directionFacing;

    float moveX, moveY;

    Animator myAnimator;
    Rigidbody2D myRigidbody;

    Transform flashLight, noFlashLight;

    bool flashLightInUse = false;
    // Use this for initialization
    void Start () {
        flashLight = transform.GetChild(0);
        noFlashLight = transform.GetChild(1);
        myAnimator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        setDarkness();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !disableFlashLight)
        {
            if (flashLightInUse)
                DisableFlashLight();
            else
                EnableFlashLight();
        }
        moveX = Input.GetAxis("Horizontal");    //Get input for x-axis
        moveY = Input.GetAxis("Vertical");      //Get input for y-axis
    }
    // Update is called once per frame
    void FixedUpdate() {
        if(flashLight)
            RotateCharacter(moveX, moveY);
        myRigidbody.velocity = new Vector2(moveX * maxSpeed, moveY * maxSpeed);
        myAnimator.SetFloat("walkX", moveX);
        myAnimator.SetFloat("walkY", moveY);
        if (moveX == 0 && moveY == 0)
            myAnimator.enabled = false;
        else
            myAnimator.enabled = true;
    }

    void changeDirectionFacing(string direction)
    {//use left, right, up, down
        directionFacing = direction;

    }
    void RotateCharacter(float moveX, float moveY)
    {
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        flashLight.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle+90));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    public void TakeDamage(float attackPower, Vector3 knockback)
    {
        myRigidbody.AddForce(knockback);
    }

    void setDarkness()
    {
        Color tmp = flashLight.GetChild(0).GetComponent<SpriteRenderer>().color;
        tmp.a = darkness;
        flashLight.GetChild(0).GetComponent<SpriteRenderer>().color = tmp;

        tmp = noFlashLight.GetComponent<SpriteRenderer>().color;
        tmp.a = darkness;
        noFlashLight.GetComponent<SpriteRenderer>().color = tmp;
    }

    public void EnableFlashLight()
    {
        flashLight.gameObject.SetActive(true);
        noFlashLight.gameObject.SetActive(false);
        flashLightInUse = true;
    }

    public void DisableFlashLight()
    {
        flashLight.gameObject.SetActive(false);
        noFlashLight.gameObject.SetActive(true);
        flashLightInUse = false;
    }
}
