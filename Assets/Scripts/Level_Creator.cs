using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Creator : MonoBehaviour
{
    [Header("Lanes Prefab")]
    public GameObject[] lanes;

    GameObject tempLane;

    [Header("Spawn Position")]
    public int zPosition = 2;

    void Start()
    {
        CreateLanes();
    }

    public void CreateLanes()
    {
        int i;
        for(i = zPosition; i < zPosition +20; i++)
        {
            tempLane = Instantiate(lanes[Random.Range(0, lanes.Length)], new Vector3(0, 0, i), Quaternion.identity) as GameObject; //Euler(-90, 90, 0)
            tempLane.transform.SetParent(gameObject.transform);
            i += tempLane.GetComponent<Lanes>().numberOfLanes - 1;
        }

        zPosition = i;
    }
}
