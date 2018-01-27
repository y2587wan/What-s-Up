using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public KeyCode leftKey;
    public KeyCode rightKey;
    public float force;
    public string playerName;

    private float moveHorizontal = 0;
    private Rigidbody2D rb2d;

	void Start () {
        rb2d = GetComponent<Rigidbody2D>();    	
	}
	
	void Update () {
        MoveMementControl();
    }

    void MoveMementControl()
    {
        if (Input.GetKey(leftKey))
            moveHorizontal = -1;
        else if (Input.GetKey(rightKey))
            moveHorizontal = 1;
        else
            moveHorizontal = 0;
        rb2d.velocity = new Vector2(moveHorizontal * speed, rb2d.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PowerUp"))
        {
            if (rb2d.velocity.y > 0)
                rb2d.AddForce(new Vector2(0, force));
            else
                rb2d.AddForce(new Vector2(0, -force));
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Head"))
        {
            Destroy(collision.transform.parent.gameObject);
        }
    }
}
