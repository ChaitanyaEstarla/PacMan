using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class FollowCamera : MonoBehaviour
{
    public Transform pacman;
    private float _offsetY;

    private void Start()
    {
        _offsetY = transform.position.y - pacman.position.y;
    }

    private void Update()
    {
        //camera should follow Pac-Man at an offset
        transform.position = new Vector3(Mathf.Clamp(pacman.position.x,-2f, 1f), pacman.position.y + _offsetY, transform.position.z);
    }
}