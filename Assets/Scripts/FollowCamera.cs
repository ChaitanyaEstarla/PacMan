using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class FollowCamera : MonoBehaviour
{
    public Transform pacman;
    private float offsetY;

    private void Start()
    {
        offsetY = transform.position.y - pacman.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(pacman.position.x,-2f, 1f), pacman.position.y + offsetY, transform.position.z);
    }
}