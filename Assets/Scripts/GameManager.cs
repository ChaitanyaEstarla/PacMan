using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int defaultRoadLength;
    
    private int startPoint;
    private int endPoint = 20;
    private const int height = 20;
    private int cameraHeight = 20;

    public GridManager grid;
    public Transform cameraTransform;
    
    void Start()
    {
        defaultRoadLength = 3;
        for (int i = 0; i < defaultRoadLength; i++)
        {
            grid.CreateLevel(startPoint, endPoint);
            startPoint += height;
            endPoint += height;
        }
    }

    private void Update()
    {
        if (cameraTransform.position.y > cameraHeight)
        {
            grid.CreateLevel(startPoint, endPoint);
            startPoint += height;
            endPoint += height;
            cameraHeight += height;
        }
    }
}
