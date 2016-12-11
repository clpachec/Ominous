using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class TextManager : MonoBehaviour {
    PlayerController player;
    GameObject itemButtonBox;
    Text text_line;
    Animator myAnimator;

    string[] sentences;

    int current_line;
    int end_line;

    bool is_active;
    bool isItemPickup = false;
    bool ignoreFirstPress = false;

    GameObject interactable;
    // Use this for initialization

    void Start () {
        myAnimator = GetComponent<Animator>();
        player = FindObjectOfType<PlayerController> ();
        text_line = transform.GetChild(0).GetComponent<Text>();
    }
	void Update()
	{
		if (!is_active)
			return; 
		if (Input.GetKeyDown (KeyCode.Space) && !ignoreFirstPress) {
            AdvanceLine();
        }
        else
        {
            ignoreFirstPress = false;
        }
	}

    void AdvanceLine()
    {
        if (current_line < sentences.Length)
            text_line.text = sentences[current_line];
        current_line += 1;
        if (current_line >= end_line)
        {
            DisableTextBox();

            if (isItemPickup)
                itemButtonBox.SetActive(true);
        }
    }

    public void ActivateTextBox(TextAsset passedtextFile, bool pickUp, GameObject passedItemButton, GameObject passedInteractable)
    {
        if (passedtextFile != null)
        {
            itemButtonBox = passedItemButton;
            interactable = passedInteractable;
            sentences = (passedtextFile.text.Split('\n'));
            current_line = 0;
            end_line = sentences.Length;
            if (current_line < sentences.Length)
            {
                text_line.text = sentences[current_line];
                is_active = true;
            }
            ignoreFirstPress = true;
            isItemPickup = pickUp;
            EnableTextBox();
        }
        
    }

	public void EnableTextBox(){
        player.canMove = false;
        myAnimator.SetTrigger("Open");
        interactable.SetActive(false);
    }

    public void DisableTextBox(){
        player.canMove = true;
        myAnimator.SetTrigger("Close");
        is_active = false;
        interactable.SetActive(true);
    }

}
