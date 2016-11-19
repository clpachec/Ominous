using UnityEngine;
using System.Collections;

public class FirstFloorEntranceEvent : MonoBehaviour {
    public Transform boy;
    public Transform door;
    public float boySpeed = 3;
    bool close;
    bool boyWalk;
    Rigidbody2D boyRigidbody;
    // Use this for initialization
    void Start () {
        boyWalk = false;
        close = false;
        boyRigidbody = boy.GetComponent<Rigidbody2D>();
        Invoke("BoyWalkUp", 1f);
    }
	
	// Update is called once per frame
	void Update () {
        if (boyWalk)
            boyRigidbody.velocity = new Vector2(0, boySpeed);
    }

    void BoyWalkUp()
    {
        boyWalk = !boyWalk;
    }

    void doorClose()
    {
        door.GetComponent<Animator>().SetTrigger("close");
        close = false;
    }

}
