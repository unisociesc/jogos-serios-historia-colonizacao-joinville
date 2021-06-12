using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood_Fix : MonoBehaviour
{
    //script to fix wooden log spawn direction
         
    void Start()
    {
        transform.rotation = Quaternion.Euler(-90,0 ,0);
    }
}
