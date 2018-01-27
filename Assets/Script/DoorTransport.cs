using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTransport : MonoBehaviour {
    public Transform ExistPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = ExistPoint.position;
        }
    }
}
