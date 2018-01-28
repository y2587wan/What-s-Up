using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour {

    public Transform degree;
    public GameObject hand;
    public GameObject body;

    private void Start()
    {
        hand.GetComponent<SpriteRenderer>().color = body.GetComponent<SpriteRenderer>().color;
    }

    void Update () {
        transform.rotation = degree.rotation;
        hand.GetComponent<SpriteRenderer>().color = body.GetComponent<SpriteRenderer>().color;
    }
}
