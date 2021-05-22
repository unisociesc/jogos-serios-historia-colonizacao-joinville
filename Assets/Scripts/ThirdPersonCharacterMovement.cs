using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public float walkSpeed = 1.2f;
    public float runSpeed = 6.0f;

    public Transform CameraT;

    private Vector2 input;
    private Vector2 inputDir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        inputDir = input.normalized;


        if (inputDir != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + CameraT.transform.eulerAngles.y;
            transform.eulerAngles = Vector3.up * targetRotation;
        }

        bool running = Input.GetKey(KeyCode.LeftShift);
        float speed = (walkSpeed + runSpeed * (running ? 1 : 0)) * inputDir.magnitude;



        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);

    }
}
