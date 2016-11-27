using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class TextManager : MonoBehaviour {
	public GameObject textBox; 
	public Text text_line; 
	public TextAsset textfile; 
	public string[] sentences; 
	public int current_line;
	public int end_line;
	public PlayerController player; 
	public bool is_active;
	public bool stop_playermove;
    bool ignoreFirstPress = false;
    // Use this for initialization
    void Start () {
		player = FindObjectOfType<PlayerController> ();
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
        }
    }

    public void ActivateTextBox(TextAsset passedtextFile)
    {
        if (passedtextFile != null)
        {
            sentences = (passedtextFile.text.Split('\n'));
            current_line = 0;
            end_line = sentences.Length;
            if (current_line < sentences.Length)
            {
                text_line.text = sentences[current_line];
                is_active = true;
            }
            ignoreFirstPress = true;
            EnableTextBox();
        }
        
    }

	public void EnableTextBox(){
		textBox.SetActive (true);
    }

	public void DisableTextBox(){
		textBox.SetActive (false);
        is_active = false;
    }

}
