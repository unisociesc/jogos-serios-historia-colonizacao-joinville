using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public Vector3 COM;
    public float MovementSpeed = 1.0f;
    public float RotationSpeed = 1.0f;
    public float movementThresold = 10.0f;

    private Transform m_COM;
    private float verticalInput;
    private float movementFactor;
    private float horizontalInput;
    private float steerFactor;
    private bool onWater;

    // Update is called once per frame

    private void Start()
    {
        if (!m_COM)
        {
            m_COM = new GameObject("COM").transform;
            m_COM.SetParent(transform);
        }
    }

    void Update()
    {
        //Balance();
        Movement();
        Steer();
        if (Mathf.Abs(steerFactor) > 0.2)
        {
            steerFactor /= 2;
        }

        if (onWater)
        {
            steerFactor = 0;
        }
        
    }

    void Balance()
    {
        m_COM.position = COM + transform.position;
        GetComponent<Rigidbody>().centerOfMass = m_COM.position;
    }

    void Movement()
    {
        float speed = (onWater) ? MovementSpeed : 0.0f;
        verticalInput = Input.GetAxis("Vertical");
        movementFactor = Mathf.Lerp(movementFactor, verticalInput, Time.deltaTime / movementThresold);
        transform.Translate(movementFactor * speed, 0.0f, 0.0f);
    }
    
    void Steer()
    {
        float speed = (onWater) ? RotationSpeed : 0.0f; 
            horizontalInput = Input.GetAxis("Horizontal");
            steerFactor = Mathf.Lerp(steerFactor, horizontalInput, Time.deltaTime / movementThresold);
            transform.Rotate(0.0f, steerFactor * RotationSpeed,0.0f );
        }

    void OnCollisionEnter(Collision collision)
    {
        onWater = (collision.gameObject.name == "oceano");
    }
}
