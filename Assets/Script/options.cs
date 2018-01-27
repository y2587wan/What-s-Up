using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class options : MonoBehaviour {

	public Transform mainMenu, optionsMenu;
	public void LoadScene (string name){
		SceneManager.LoadScene(name);
	}
}
