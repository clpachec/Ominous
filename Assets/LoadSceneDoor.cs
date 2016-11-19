using UnityEngine;
using System.Collections;

public class LoadSceneDoor : MonoBehaviour {
    public Transform Load;
    private Animator LoadAnimator;

    // Use this for initialization
    void Start()
    {
        LoadAnimator = Load.GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GetComponent<Animator>().SetTrigger("open");
            GetComponent<AudioSource>().Play();
            Debug.Log(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
            Invoke("LoadScene", 1);
        }
    }
        
    void LoadScene()
    {
        LoadAnimator.SetTrigger("Fade");
    }
}
