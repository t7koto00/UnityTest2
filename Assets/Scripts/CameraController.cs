using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CameraController : NetworkBehaviour
{

    public GameObject player;

    private Vector3 offset;

    void Start()
    {
        if (!isLocalPlayer)
        {
            // exit from update if this is not the local player
            return;
        }
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        if (!isLocalPlayer)
        {
            // exit from update if this is not the local player
            return;
        }
        transform.position = player.transform.position + offset;
    }
}
