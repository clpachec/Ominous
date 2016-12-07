using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ActivateGameOver : MonoBehaviour {

    GameObject gameOver;
	// Use this for initialization
	void Start () {
        gameOver = GameObject.FindGameObjectWithTag("Game Over");
        if(gameOver)
            gameOver.GetComponent<Animator>().SetTrigger("Fade");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
