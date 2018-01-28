using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorController : MonoBehaviour {
	void Start () {
        transform.Rotate(0, 0,Random.Range(-180f, 180f));
	}
}
