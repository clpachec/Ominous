﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    private Animator myAnimator;

    public float maxSpeed = 9f;

    // Use this for initialization
    void Start () {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        float moveX = Input.GetAxis("Horizontal");    //Get input for x-axis
        float moveY = Input.GetAxis("Vertical");      //Get input for y-axis

        //RotateCharacter(moveX, moveY);
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * maxSpeed, moveY * maxSpeed);
        myAnimator.SetFloat("walkX", moveX);
        myAnimator.SetFloat("walkY", moveY);
    }

    void RotateCharacter(float moveX, float moveY)
    {
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
