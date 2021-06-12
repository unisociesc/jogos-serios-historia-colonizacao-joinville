using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Player Reference")]
    public Transform player;

    Vector3 offset;

    void Start()
    {
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(player.position.x + offset.x, offset.y, player.position.z + offset.z);
    }
}
