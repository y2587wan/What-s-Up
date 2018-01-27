using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestoryBasedOnTime : MonoBehaviour {

    public float maxExistingTime;

    private float existingTime = 0;

	void Update () {
        existingTime += Time.deltaTime;
        if (existingTime > maxExistingTime)
            Destroy(gameObject);
	}
}
