﻿using UnityEngine;
using System.Collections;

public class InteractableTextBox : MonoBehaviour {
    public TextAsset textFile;
    public bool playerFacingLeft = true;
    public bool playerFacingRight = true;
    public bool playerFacingDown = true;
    public bool playerFacingUp = true;
    public PlayerController player;
    public bool pickUp = false;
    public GameObject itemButton;
    public bool seeOnce;
    public GameObject remove;
    TextManager textManager;
    bool entered = false;
    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerController>();
        textManager = FindObjectOfType<TextManager>();
    }

    // Update is called once per frame
    void Update () {
        if (entered)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if ((player.directionFacing == "left" && playerFacingLeft) ||
                   (player.directionFacing == "right" && playerFacingRight) ||
                   (player.directionFacing == "down" && playerFacingDown) ||
                   (player.directionFacing == "up" && playerFacingUp))
                {
                    textManager.ActivateTextBox(textFile, pickUp, itemButton, gameObject);
                    if (seeOnce)
                    {
                        remove.SetActive(false);
                        gameObject.SetActive(false);
                    }
                }
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            entered = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            entered = false;
        }
    }
}
