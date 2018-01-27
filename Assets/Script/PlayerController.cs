using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float rotateSpeed;
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode rotateLeft;
    public KeyCode rotateRight;
    public float force;
    public string playerName;
    public Transform rotatePoint;
    public int maxJumpNum = 5;

    private float rotateClockwise = 1;
    private float moveHorizontal = 0;
    private Rigidbody2D rb2d;
    private Vector3 zAxis;
    private int jumpCollectCounter = 0;

	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        zAxis = new Vector3(0, 0, 1);
	}
	
	void Update () {
        MoveMementControl();
        RotateShootPoint();
    }

    private void RotateShootPoint()
    {
        if (Input.GetKey(rotateLeft))
            rotateClockwise = -1;
        else if (Input.GetKey(rotateRight))
            rotateClockwise = 1;
        else
            rotateClockwise = 0;
        rotatePoint.RotateAround(transform.position, zAxis, rotateSpeed * rotateClockwise);
    }

    private void MoveMementControl()
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
        if (jumpCollectCounter < maxJumpNum && collision.CompareTag("PowerUp"))
        {
            jumpCollectCounter++;
            if (rb2d.velocity.y > 0)
                rb2d.AddForce(new Vector2(0, force));
            else
                rb2d.AddForce(new Vector2(0, -force));
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            Debug.Log(playerName + " Win!");
        }
    }
}
