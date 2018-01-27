using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Laser"))
        {
            Destroy(collision.gameObject);
            var player = transform.parent.parent;
            player.GetComponent<PlayerController>().EnergyCount++;
            Debug.Log("Energy: " + player.GetComponent<PlayerController>().EnergyCount);
        }
    }
}
