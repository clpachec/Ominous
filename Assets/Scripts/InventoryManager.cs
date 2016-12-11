using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {
    bool inventoryBoxActive;
    PlayerController player;
    Animator myAnimator;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        myAnimator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (inventoryBoxActive)
                DisableInventoryBox();
            else
                EnableInventoryBox();
        }
    }

    public void EnableInventoryBox()
    {
        myAnimator.SetTrigger("Open");
        inventoryBoxActive = true;
        player.canMove = false;
    }

    public void DisableInventoryBox()
    {
        myAnimator.SetTrigger("Close");
        inventoryBoxActive = false;
        player.canMove = true;
    }
}
