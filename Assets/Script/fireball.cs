using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour {

    private Vector2 originalPosiiton;
    private float originalTime = 0;
    public float maxTime = 10;

	void Start () {
        originalPosiiton = transform.position;
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (-5, -5);
	}
	
	// Update is called once per frame
	void Update () {
        originalTime += Time.deltaTime;
        if (originalTime > maxTime)
        {
            transform.position = originalPosiiton;
            originalTime = 0;
        }
	}
}
