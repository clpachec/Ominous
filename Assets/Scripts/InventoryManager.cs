using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {
    public GameObject inventoryBox;
    bool inventoryBoxActive;
    PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
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
        inventoryBox.SetActive(true);
        inventoryBoxActive = true;
        player.canMove = false;
    }

    public void DisableInventoryBox()
    {
        inventoryBox.SetActive(false);
        inventoryBoxActive = false;
        player.canMove = true;
    }
}
