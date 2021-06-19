using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCtrl : MonoBehaviour
{
    public GravityOrbit Gravity;
    public float RotationSpeed = 20;

    private Rigidbody Rb;
    
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        if (Gravity)
        {
            //Vector3 gravityUp = Vector3.zero;
            //gravityUp = (transform.position - Gravity.transform.position).normalized;

            //Vector3 localUp = transform.up;

            //Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * transform.rotation;

            //transform.up = Vector3.Lerp(transform.up, gravityUp, RotationSpeed * Time.deltaTime);

            //Rb.AddForce((-gravityUp * Gravity.Gravity) * Rb.mass);


            Vector3 gravityUp = Vector3.zero;

            gravityUp = (transform.position - Gravity.transform.position).normalized;

            Vector3 localUp = transform.up;

            Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * transform.rotation;
            Rb.GetComponent<Rigidbody>().rotation = targetRotation;

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
            Rb.GetComponent<Rigidbody>().AddForce((-gravityUp * Gravity.Gravity) * Rb.mass);
        }
    }
}
