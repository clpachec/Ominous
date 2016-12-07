using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {


    public int health = 100;
    public float maxSpeed = 9f;
    public float darkness = 0.8f;
    public float healthRecoveryTime = .5f;          //Time intervals which health is added
    public float recoveryDelay = 1f;                //Time before starting to recover again after a hit
    public bool disableFlashLight = false;
    public string directionFacing;
    public bool canMove = true;
    int fullHealth;
    float moveX, moveY;

    Animator myAnimator;
    Rigidbody2D myRigidbody;

    Transform flashLight, noFlashLight;

    GameObject bloodSplatterEffect;
    GameObject gameOverScreen;

    bool flashLightInUse = false;
    // Use this for initialization
    void Start () {
        flashLight = transform.GetChild(0);
        noFlashLight = transform.GetChild(1);
        myAnimator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        setDarkness();

        fullHealth = health;
        bloodSplatterEffect = GameObject.FindGameObjectWithTag("Blood Splatter");
        gameOverScreen = GameObject.FindGameObjectWithTag("Game Over");

        ApplyBloodSplatterEffect();
    }

    void Update()
    {
        if (canMove)
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
        else
        {
            moveX = 0;
            moveY = 0;
        }
    }
    // Update is called once per frame
    void FixedUpdate() {
        if(flashLight)
            RotateCharacter(moveX, moveY);
        //myRigidbody.velocity = new Vector2(moveX * maxSpeed, moveY * maxSpeed);

        var x = moveX * Time.deltaTime * maxSpeed;
        var y = moveY * Time.deltaTime * maxSpeed;

        transform.Translate(x, y, 0);

        myAnimator.SetFloat("walkX", moveX);
        myAnimator.SetFloat("walkY", moveY);
        if (moveX == 0 && moveY == 0)
            myAnimator.enabled = false;
        else
            myAnimator.enabled = true;
        if(health <= 0)
        {
            activateDeath();
        }
    }

    public void moveActive()
    {
        canMove = true;
    }
    void activateDeath()
    {
        if (gameOverScreen)
        {
            canMove = false;
            gameOverScreen.GetComponent<Animator>().SetTrigger("Fade");
        }
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

    public void TakeDamage(int attackPower, Vector3 knockback)
    {
        CancelInvoke("RecoverHealth");
        InvokeRepeating("RecoverHealth", recoveryDelay, healthRecoveryTime);
        health -= attackPower;
        ApplyBloodSplatterEffect();
        //myRigidbody.AddForce(knockback);
    }

    void ApplyBloodSplatterEffect()
    {
        if (bloodSplatterEffect != null && health < fullHealth)
        {
            float alpha = (float)(fullHealth - health) / 100f;

            if (fullHealth - (fullHealth - health) <= 10)
                alpha = 1.0f;
            bloodSplatterEffect.GetComponent<Image>().color = new Color(1f, 1f, 1f, alpha);
        }
        else if(bloodSplatterEffect != null)
            bloodSplatterEffect.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
    }

    public void setDarkness()
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

    void RecoverHealth()
    {
        health++;
        ApplyBloodSplatterEffect();
        if (health >= fullHealth)
        {
            health = fullHealth;
            
            CancelInvoke("RecoverHealth");
        }
    }
}
