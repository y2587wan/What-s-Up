using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    public Text winText;
    private int time = 1;

	void Update () {
        StartCoroutine(WaitforSecond(time));
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

    private IEnumerator WaitforSecond(int time)
    {
        yield return new WaitForSeconds(time);
        WinCondition();
    }
}
