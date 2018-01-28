using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour {


	void Start () {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (Random.Range(-10, -5f), Random.Range(-5f, -2.5f));
	}
}
