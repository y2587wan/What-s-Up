using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointRandomGeneration : MonoBehaviour {

    public GameObject mirror;
    public GameObject powerUp;
    public GameObject energyUp;
    public GameObject transformer;
    public GameObject transformerEnter;
    public GameObject transformerExit;
    public Collider2D uperArea;
    public float spawnTime;
    public float transformerSpawnTime;
    public int maxNumOfPoint = 10;

    private float timeCounter = 0;
    private float transformerTime = 0;
    private Collider2D transformerArea;

    void Start () {
        transformerArea = transformer.GetComponent<BoxCollider2D>();
        RandomGeneration(powerUp, uperArea, transform);
    }
	
	// Update is called once per frame
	void Update () {
        timeCounter += Time.deltaTime;
        transformerTime += Time.deltaTime;
        //Debug.Log(timeCounter);
        if(timeCounter >= spawnTime && transform.childCount < maxNumOfPoint)
        {
            RandomGeneration(powerUp, uperArea, transform);
            RandomGeneration(mirror, uperArea, transform);
            RandomGeneration(energyUp, uperArea, transform);
            timeCounter = 0;
        }

        if (transformerTime > transformerSpawnTime && transformer.transform.childCount < 2)
        {
            RandomGeneration(transformerEnter, transformerArea, transformer.transform);
            RandomGeneration(transformerExit, transformerArea, transformer.transform);
            var enter = transformer.transform.GetChild(0);
            var exit = transformer.transform.GetChild(1);
            exit.position = new Vector2(exit.position.x, enter.position.y);
            enter.GetComponent<DoorTransport>().ExistPoint = exit;
            exit.GetComponent<DoorTransport>().ExistPoint = enter;
        }
    }

    void RandomGeneration(GameObject item, Collider2D area, Transform parent)
    {
        Vector2 minPoint = area.bounds.min;
        Vector2 maxPoint = area.bounds.max;
        float x = Random.Range(minPoint.x + 0.1f, maxPoint.x - 0.1f);
        float y = Random.Range(minPoint.y + 0.1f, maxPoint.y - 0.1f);
        Vector2 generatePoint = new Vector2(x, y);
        var child = (GameObject)Instantiate(item, generatePoint, Quaternion.Euler(Vector3.zero));
        child.transform.parent = parent;
    }
}
