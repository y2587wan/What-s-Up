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
    public KeyCode shootButton;
    public float jumpForce;
    public string playerName;
    public float shootForce;
    public Transform rotatePoint;
    public GameObject bullet;   
    public int maxJumpNum = 5;
    public GameObject bulletGameManager;

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
        ShootBullet();
    }

    private void ShootBullet()
    {
        var bulletCount = bulletGameManager.GetComponent<BulletManager>().PlayerLaser[playerName];
        if (Input.GetKey(shootButton) && bulletCount == 0)
        {
            Debug.Log(playerName + bulletCount);
            var child = (GameObject)Instantiate(bullet, rotatePoint.position, Quaternion.Euler(Vector3.zero));
            child.GetComponent<LaserController>().PlayerName = playerName;
            child.transform.parent = bulletGameManager.transform;
            var childRb2d = child.GetComponent<Rigidbody2D>();
            childRb2d.velocity = Vector2.zero;
            var direction = rotatePoint.position - transform.position;
            var shootingSpeed = direction.normalized * shootForce;
            childRb2d.AddForce(shootingSpeed);
            bulletGameManager.GetComponent<BulletManager>().PlayerLaser[playerName]++;
        }
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
                rb2d.AddForce(new Vector2(0, jumpForce));
            else
                rb2d.AddForce(new Vector2(0, -jumpForce));
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Head"))
        {
            var otherPlayer = collision.transform.parent.gameObject;
            Destroy(otherPlayer);
            Debug.Log(playerName + " Win!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
            Destroy(gameObject);
    }
}
