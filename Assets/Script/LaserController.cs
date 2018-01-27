using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour {

    public float maxHeight = 20f;
    public string PlayerName { get; set; }

	void Update () {
        LaserSelfDestory();
    }

    private void LaserSelfDestory()
    {
        if (transform.position.y > maxHeight)
            Destroy(gameObject);
    }
}
