using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour {

    public float maxTime = 5f;
    public float maxHeight = 20f;
    public string PlayerName { get; set; }
    public GameObject laserPoint;

    private Vector2 previousPoint;
    private Vector2 previousSpeed;
    private float timeCounter = 0;
    private bool doesNextPointExist = false;
    private GameObject nextPoint;
    private void Start()
    {
        previousPoint = transform.position;
        previousSpeed = GetComponent<Rigidbody2D>().velocity;
    }

    void Update () {
        LaserSelfDestory();
        timeCounter += Time.deltaTime;
        if (!doesNextPointExist && timeCounter > maxTime)
        {
            nextPoint = (GameObject)Instantiate(laserPoint, previousPoint, transform.rotation);
            nextPoint.GetComponent<Rigidbody2D>().velocity = previousSpeed;
            doesNextPointExist = true;
        }

        if (timeCounter > maxTime)
        {
            nextPoint.transform.position = previousPoint;
            nextPoint.GetComponent<Rigidbody2D>().velocity = previousSpeed;
            previousSpeed = GetComponent<Rigidbody2D>().velocity;
            previousPoint = transform.position;
            timeCounter = 0;
        }
    }

    private void LaserSelfDestory()
    {
        if (transform.position.y > maxHeight)
            Destroy(gameObject);
    }
}
