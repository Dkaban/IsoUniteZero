using System;
using System.Collections;
using System.Collections.Generic;
using Code.Managers;
using UnityEngine;
using Zenject;

public class CameraFollow : MonoBehaviour
{
    [Inject] private IsoWorldManager _isoWorldManager;
    private const float CameraHeight = 20.0f;

    private void Update()
    {
        if (_isoWorldManager.PlayerObject != null)
        {
            var pos = _isoWorldManager.PlayerObject.transform.position;
            pos.y = 0;
            transform.position = pos;
        }
    }
}
