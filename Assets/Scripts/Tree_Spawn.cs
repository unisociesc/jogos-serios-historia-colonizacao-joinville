using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_Spawn : MonoBehaviour
{
    //spawn tree with a random rotation

    void Start()
    {
        transform.rotation = Quaternion.Euler(0, Random.Range(0, 90),0);
    }
}
