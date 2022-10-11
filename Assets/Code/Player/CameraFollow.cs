using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject PlayerObject;
    private const float CameraHeight = 20.0f;

    private void Update()
    {
        if (PlayerObject != null)
        {
            var pos = PlayerObject.transform.position;
            pos.z += CameraHeight;
            transform.position = pos;
        }
    }
}
