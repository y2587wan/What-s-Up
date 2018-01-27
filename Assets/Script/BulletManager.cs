using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {

    public Dictionary<string, int> PlayerLaser;

    private void Start()
    {
        PlayerLaser = new Dictionary<string, int>
        {
            { "Player 1", 0},
            { "Player 2", 0}
        };
    }

    private void FixedUpdate()
    {
        Debug.Log("Child num: " + transform.childCount);
        if (transform.childCount == 0)
        {
            foreach (var key in PlayerLaser.Keys)
            {
                if (PlayerLaser[key] != 0)
                    PlayerLaser[key] = 0;
            }
        }

        else if(transform.childCount == 1)
        {
            var child = transform.GetChild(0);
            if (child.GetComponent<LaserController>().PlayerName == "Player 1")
                PlayerLaser["Player 2"] = 0;
            else
                PlayerLaser["Player 1"] = 0;
        }
    }
}
