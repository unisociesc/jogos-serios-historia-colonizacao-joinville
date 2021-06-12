using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjects : MonoBehaviour
{
    [Header("Speeds")]
    public float minSpeed;
    public float maxSpeed;

    Rigidbody rb;
    Vector3 newVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        newVelocity = new Vector3(Random.Range(minSpeed, maxSpeed), 0, 0);
    }

    void FixedUpdate()
    {
        rb.velocity = newVelocity;
    }

    //destroy if hits the wall
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Car_Wall"))
        {
            Destroy(gameObject);
        }
    }
}
