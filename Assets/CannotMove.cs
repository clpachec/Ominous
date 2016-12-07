using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannotMove : MonoBehaviour {
    PlayerController player;
    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerController>();
        if (player)
            player.canMove = false;
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (player)
            player.canMove = false;
    }
}
