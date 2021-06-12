using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    [Header("Objects to spawn")]
    public GameObject[] objects;

    [Header("Min / Max times")]
    public float minSpawnTime;
    public float maxSpawnTime;

    [Header("Booleans")]
    public bool spawnMovingObjects = false;
    public bool isLeft;

    void Start()
    {
        if (spawnMovingObjects)
        {
            SpawnMovingObjects();
        }
        else
        {
            SpawnStaticObjects();
        }
    }

    void SpawnMovingObjects()
    {                   
        if(isLeft == true)
        {
            Instantiate(objects[Random.Range(0, objects.Length)], transform.position, Quaternion.Euler(-90,90,180));

            Invoke("SpawnMovingObjects", Random.Range(minSpawnTime, maxSpawnTime));
        }
        else
        {
            Instantiate(objects[Random.Range(0, objects.Length)], transform.position, Quaternion.Euler(-90,90,0));

            Invoke("SpawnMovingObjects", Random.Range(minSpawnTime, maxSpawnTime));     
        }
    }

    void SpawnStaticObjects()
    {                            
        for (int i = 0; i < Random.Range(1, 3); i++)
        {                                                                                                                              
            Instantiate(objects[Random.Range(0, objects.Length)], new Vector3(Random.Range(-10, 10), 0, transform.position.z), Quaternion.identity);
        }
    }
}
