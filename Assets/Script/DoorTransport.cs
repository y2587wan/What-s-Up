using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTransport : MonoBehaviour {
    public Transform ExistPoint;
    private Vector3 up = new Vector3(0, 1, 0);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = ExistPoint.position + up;
            collision.GetComponent<Rigidbody2D>().velocity *= -1;
        }
    }
}
