using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class options : MonoBehaviour {

	public Transform mainMenu, optionsMenu;
	public void LoadScene (string name){
		Application.LoadLevel (name);
	}
}
