using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public int attackPower = 10;
    public float health = 10;
    public float knockback = 100;
    public float movementSpeed = 5;
    public float attackDelay = 0.5f;
    Rigidbody2D myRigidbody;
    GameObject player;
    bool followPlayer;
    Animator myAnimator;
    bool facingRight;
    bool canMove = true;
    bool dead = false;
    bool canAttack = true;
    Vector3 distance;
    public ParticleSystem damageParticle;
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
            myAnimator.SetTrigger("death");
            canMove = false;
            dead = true;
        }

        if (dead)
        {
            gameObject.layer = 8;
        }
        if (canMove)
        {
            distance = transform.position - player.transform.position;
            if (followPlayer)
                myRigidbody.velocity = -(distance.normalized * movementSpeed);

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

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && canAttack)
        {
            //Debug.Log(myRigidbody.velocity.normalized);
            //Debug.Log(myRigidbody.velocity.normalized * knockback);
            
            col.gameObject.GetComponent<PlayerController>().TakeDamage(attackPower, myRigidbody.velocity.normalized * knockback);
            followPlayer = false;
            canAttack = false;
            myAnimator.SetTrigger("projectAttack");
            myAnimator.SetTrigger("attack");

            Invoke("Wait", attackDelay);
        }
    }

    void Wait()
    {
        followPlayer = true;
        canAttack = true;
        return;
    }

    public void damageEnemy(float damage)
    {
        health -= damage;
        damageParticle.Play();
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
