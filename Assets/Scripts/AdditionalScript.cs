using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionalScript : MonoBehaviour {
    public TextAsset textFile;
    public bool activateObject;
    public GameObject objectToSetActive;
    public GameObject objectToRemove;

    TextManager textManager;
    GameObject itemButton;
    // Use this for initialization
    void Start () {
        textManager = FindObjectOfType<TextManager>();
    }

    public void activateDialogue()
    {
        textManager.ActivateTextBox(textFile, activateObject, objectToSetActive, gameObject);
        if (objectToRemove)
            objectToRemove.SetActive(false);
    }
}
