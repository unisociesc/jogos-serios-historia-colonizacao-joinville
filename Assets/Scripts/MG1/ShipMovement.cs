using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using Random2 = UnityEngine.Random;

public class ShipMovement : MonoBehaviour
{
    public Vector3 COM;
    public float MovementSpeed = 1.0f;
    public float RotationSpeed = 1.0f;
    public float WaveRotationSpeed = 0.1f;
    public float WindForce = 2.0f;
    public float movementThresold = 10.0f;
    public float maxMovement = 0.2f;
    public float maxRotation = 0.2f;
    public float timeToWave = 0.5f;
    public float timeToWind = 0.5f;

    private Transform m_COM;
    private float verticalInput;
    private float movementFactor;
    private float horizontalInput;
    private float steerFactor;
    private bool onWater;
    private float wave;
    private float wind;

    // Update is called once per frame

    private void Start()
    {
        wave = 0.0f;
        InvokeRepeating("waveRandom", 2.0f, timeToWave);
        InvokeRepeating("windRandom", 2.0f, timeToWind);
        if (!m_COM)
        {
            m_COM = new GameObject("COM").transform;
            m_COM.SetParent(transform);
        }
    }

    void waveRandom()
    {
        wave = Random2.Range(-WaveRotationSpeed, WaveRotationSpeed);
    }

    void windRandom()
    {
        wind = Random2.Range(0.5f, WindForce);
    }

    void LateUpdate()
    {
        //Balance();
        Movement();
        Steer();
        Wave();
        Debug.Log("wave factor: "+steerFactor);
        Debug.Log("wind factor: "+wind);
        if (steerFactor > maxRotation)
        {
            steerFactor = maxRotation;
        }
        else if (Mathf.Abs(steerFactor) < -maxRotation)
        {
            steerFactor = -maxRotation;
        }

        if (movementFactor > maxMovement)
        {
            movementFactor = maxMovement;
        }
        else if (movementFactor < -maxMovement)
        {
            movementFactor = -maxMovement;
        } 
    }

    void Wave()
    {
        steerFactor = Mathf.Lerp(steerFactor, wave, Time.deltaTime / movementThresold);
        transform.Rotate(0.0f, steerFactor * wave,0.0f );
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
        transform.Translate(movementFactor * speed * wind, 0.0f, 0.0f);
    }
    
    void Steer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        steerFactor = Mathf.Lerp(steerFactor, horizontalInput, Time.deltaTime / movementThresold);
        transform.Rotate(0.0f, steerFactor * RotationSpeed, 0.0f );
    }

    private void OnCollisionStay(Collision collision)
    {
        onWater = true;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "MG1_MAPA")
        {
            movementFactor = 0;
            steerFactor = 0;
        }
            
    }
}
