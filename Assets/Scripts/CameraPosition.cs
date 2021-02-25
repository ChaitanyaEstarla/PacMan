using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public Transform target;
    Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        Vector3 viewportToScreenPoint = cam.ViewportToScreenPoint(target.position);
        
        Debug.Log(viewportToScreenPoint);
    }

    void Update()
    {
        
    }
}
