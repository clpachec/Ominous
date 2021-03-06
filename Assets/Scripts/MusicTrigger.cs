﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    public AudioSource music;
    public bool playOnEnter = true;
    public bool triggerOnce = true;
    public bool musicStopOnExit = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (playOnEnter)
            {
                music.Play();
                if (triggerOnce)
                    gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (musicStopOnExit)
            {
                music.Stop();
                if (triggerOnce)
                    gameObject.SetActive(false);
            }
        }
    }
}