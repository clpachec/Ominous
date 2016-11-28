using UnityEngine;
using System.Collections;

public class InventoryManager : MonoBehaviour {
    public GameObject inventoryBox;
    bool inventoryBoxActive;
    // Use this for initialization
    void Start () {
	
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
    }

    public void DisableInventoryBox()
    {
        inventoryBox.SetActive(false);
        inventoryBoxActive = false;
    }
}
