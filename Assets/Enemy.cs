using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    float attackPower;
    public float health = 10;
    public float knockback = 100;
    public float movementSpeed = 5;
    Rigidbody2D myRigidbody;
    GameObject player;
    bool followPlayer;
    Animator myAnimator;
    bool facingRight;
    bool canMove = true;
    bool dead = false;
    // Use this for initialization
    void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        followPlayer = true;
        facingRight = true;
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log((transform.position - player.transform.position));
        //Debug.Log((transform.position - player.transform.position).normalized);
        
        if(health < 0 && !dead)
        {
            GetComponent<Animator>().SetTrigger("death");
            canMove = false;
            dead = true;
        }

        if (dead)
        {
            gameObject.layer = 8;
        }
        if (canMove)
        {
            if (followPlayer)
                myRigidbody.velocity = -((transform.position - player.transform.position).normalized) * movementSpeed;

            if (facingRight)
                myAnimator.SetFloat("x", myRigidbody.velocity.x);
            else
                myAnimator.SetFloat("x", -myRigidbody.velocity.x);
            if (myRigidbody.velocity.x < 0 && facingRight)
            {
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
                facingRight = !facingRight;
            }
            if (myRigidbody.velocity.x > 0 && !facingRight)
            {
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
                facingRight = !facingRight;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("collision2d Enter");
        if (col.gameObject.tag == "Player")
        {
            //Debug.Log(myRigidbody.velocity.normalized);
            //Debug.Log(myRigidbody.velocity.normalized * knockback);
            
            col.gameObject.GetComponent<PlayerController>().TakeDamage(attackPower, myRigidbody.velocity.normalized * knockback);
            followPlayer = false;
            Invoke("Wait", 1);
        }
    }

    void Wait()
    {
        followPlayer = true;
        return;
    }

    public void damageEnemy(float damage)
    {
        health -= damage;
    }

    public void movementOn()
    {
        canMove = true;
    }

    public void movementOff()
    {
        canMove = false;
    }
    //NOTE: Might change for efficiency issue
}
