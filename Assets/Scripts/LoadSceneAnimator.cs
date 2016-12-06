using UnityEngine;
using System.Collections;

public class LoadSceneAnimator : MonoBehaviour {
    public Transform Load;
    private Animator LoadAnimator;

	// Use this for initialization
	void Start () {
        LoadAnimator = Load.GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            LoadAnimator.SetTrigger("Fade");
            if (GetComponent<AudioSource>())
                GetComponent<AudioSource>().Play();
        }
    }
}
