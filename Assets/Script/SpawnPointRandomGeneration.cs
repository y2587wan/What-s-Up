using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointRandomGeneration : MonoBehaviour {

    public GameObject mirror;
    public GameObject powerUp;
    public GameObject energyUp;
    public Collider2D area;
    public float spawnTime;
    public int maxNumOfPoint = 10;

    private float timeCounter = 0;

    void Start () {
        RandomGeneration(powerUp);
    }
	
	// Update is called once per frame
	void Update () {
        timeCounter += Time.deltaTime;
        //Debug.Log(timeCounter);
        if(timeCounter >= spawnTime && transform.childCount < maxNumOfPoint)
        {
            RandomGeneration(powerUp);
            RandomGeneration(mirror);
            RandomGeneration(energyUp);
            timeCounter = 0;
        }
    }

    void RandomGeneration(GameObject item)
    {
        Vector2 minPoint = area.bounds.min;
        Vector2 maxPoint = area.bounds.max;
        float x = Random.Range(minPoint.x + 1, maxPoint.x - 1);
        float y = Random.Range(minPoint.y + 1, maxPoint.y - 1);
        Vector2 generatePoint = new Vector2(x, y);
        var child = (GameObject)Instantiate(item, generatePoint, Quaternion.Euler(Vector3.zero));
        child.transform.parent = gameObject.transform;
    }
}
