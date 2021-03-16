using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class FollowCamera : MonoBehaviour
{
    public Transform pacMan;

    private int _setActiveAfterHeight = 20; 
    private float _offsetY;
    private Transform _cameraTransform;

    private void Start()
    {
        _offsetY = transform.position.y - pacMan.position.y;
        _cameraTransform = gameObject.transform;
    }

    private void Update()
    {
        //camera should follow Pac-Man at an offset
        _cameraTransform.position = new Vector3(Mathf.Clamp(pacMan.position.x,-2f, 1f), pacMan.position.y + _offsetY, transform.position.z);

        if (!(_cameraTransform.position.y >= _setActiveAfterHeight)) return;
        ObjectPooler.SetGameObjectActive();
        _setActiveAfterHeight += 10;
    }
    
    
}