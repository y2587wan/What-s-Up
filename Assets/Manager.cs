using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    public Text winText;

	void Update () {
        WinCondition();
    }

    private void WinCondition()
    {
        if (transform.childCount == 0)
        {
            winText.gameObject.SetActive(true);
            winText.text = "Both of you lose!";
        }
        else if (transform.childCount == 1)
        {
            winText.gameObject.SetActive(true);
            winText.text = transform.GetChild(0).GetChild(0).GetComponent<PlayerController>().playerName + " Win!!";
        }
    }
}
