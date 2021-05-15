using UnityEngine;

public class RTS_CameraController : MonoBehaviour
{
    public float panSpeed = 0.20f;
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        
        if (Input.GetKey("w"))
        {
            pos.z += panSpeed;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= panSpeed;
        }
        if (Input.GetKey("s"))
        {
            pos.z -= panSpeed;
        }
        if (Input.GetKey("d"))
        {
            pos.x += panSpeed;
        }

        transform.position = pos;
    }
}
