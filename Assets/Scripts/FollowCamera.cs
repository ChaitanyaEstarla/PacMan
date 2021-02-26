using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class FollowCamera : MonoBehaviour
{
    public Transform pacman;

    private Vector3 _offset;

    void Update()
    {
        _offset = transform.position - pacman.position;
    }

    private void LateUpdate()
    {
        Vector2 newPos = pacman.position + _offset;
        
        //transform.position = Vector2.Lerp(transform.position, newPos, )
    }
}
