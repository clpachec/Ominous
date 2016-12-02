using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DamageEnemy : MonoBehaviour {

    HashSet<GameObject> enemyHash = new HashSet<GameObject>();
    public float slowDownEnemy = 5;
	// Use this for initialization
	void Start () {
        //Invoke when you start your flash light
        //Cancel Invoke when you turn off your flash light
        InvokeRepeating("damageEnemies", 0f, .5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<Enemy>().movementSpeed /= slowDownEnemy;
            if (!enemyHash.Contains(col.gameObject))
                enemyHash.Add(col.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<Enemy>().movementSpeed *= slowDownEnemy;
            if (enemyHash.Contains(col.gameObject))
                enemyHash.Remove(col.gameObject);
        }
    }

    void damageEnemies()
    {
        foreach(GameObject target in enemyHash)
        {
            //target.GetComponent<Animator>().SetTrigger("stun");
            target.GetComponent<Enemy>().damageEnemy(1);
        }
    }
}
