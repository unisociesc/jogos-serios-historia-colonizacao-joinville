using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform playerTransform;
    [Range(0.01f, 100.0f)]
    public float smoothFactor = 0.5f;
    
    private Vector3 _cameraOffset;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _cameraOffset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = playerTransform.position + _cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);
    }
}
