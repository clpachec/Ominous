using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class itemDescription : MonoBehaviour {
    public Text descriptionPanel;
    public string description;

    public void changeDescription()
    {
        descriptionPanel.text = description;
    }

    public void blankDescription()
    {
        descriptionPanel.text = "";
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
