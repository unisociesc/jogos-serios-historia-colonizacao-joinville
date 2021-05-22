using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ThirdPersonCameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    
    private float Yaw;
    private float Pitch;

    private Vector3 rotationSmoothVelocity;
    private Vector3 currentRotation;
    

    public Transform target;

    //this vector 2 limits the pitch rotation
    public Vector2 PitchMinMax = new Vector2(-35, 65);
    
    
    public float rotationSmoothTime = 0.2f;
    public float distanceForTarget = 2;
    public int mouseSensitivity = 10;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Yaw    += Input.GetAxis("Mouse X") * mouseSensitivity;
        Pitch  -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        Pitch = Mathf.Clamp(Pitch, PitchMinMax.x, PitchMinMax.y);

        currentRotation = Vector3.SmoothDamp(currentRotation,
                                            new Vector3(Pitch, Yaw), 
                                            ref rotationSmoothVelocity,
                                            rotationSmoothTime);

        transform.eulerAngles = currentRotation;
        
        transform.position = target.position - transform.forward * distanceForTarget;
    }
}
