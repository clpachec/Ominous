using UnityEngine;
using System.Collections;

public class TextImporter : MonoBehaviour {

	public TextAsset textfile; 
	public string[] sentences; 



	// Use this for initialization
	void Start () {

		if (textfile != null) {

			sentences = (textfile.text.Split ('\n')); 

		}

	
	}
	

}