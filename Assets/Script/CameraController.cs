using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;
    public float smoothSpeed = 1.0f;
    public float sizeFactor;

    private float distance;
    private float originalDistance;
    private float targetOrtho;
    private float cameraY;
    private float minSize;
    private float maxSize;
    private float originalFactor = 1;

	void Start () {
        targetOrtho = Camera.main.orthographicSize;
        minSize = targetOrtho;
        PlayerDistance();
        originalDistance = distance;
        cameraY = transform.position.y - Camera.main.orthographicSize;
        maxSize = targetOrtho * sizeFactor;
    }
	
	void Update () {
        if (player1 != null && player2 != null)
        {
            PlayerDistance();
            ChangeDistance();
        }
    }

    private void PlayerDistance()
    {
        distance = player1.transform.position.y / player2.transform.position.y;
        // Debug.Log("Distance: " + distance);
    }

    private void ChangeDistance()
    {
        var factor = distance / originalDistance;
        // Debug.Log("Factor: " + factor);
        if (factor / originalFactor > 1f)
        {
            targetOrtho = targetOrtho * factor;
            targetOrtho = Mathf.Clamp(targetOrtho, minSize, maxSize);
            Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, cameraY + Camera.main.orthographicSize, transform.position.z);
            originalFactor = factor;
            originalDistance = distance;
        }
    }
}
