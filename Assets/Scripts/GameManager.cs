using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Default tile chunks generated at the beginning of the game
    public int defaultRoadLength;
    
    private int startPoint;
    private int endPoint = 20;
    private const int height = 20; //Default height I've chosen right now. This is used for level generation
    private int cameraHeight = 20; //Detecting the camera transform to generate further levels

    public GridManager grid;
    public Transform cameraTransform;
    
    void Start()
    {
        //Initial gird generated at the beginning of the game
        for (int i = 0; i < defaultRoadLength; i++)
        {
            grid.CreateLevel(startPoint, endPoint);
            startPoint += height;
            endPoint += height;
        }
    }

    private void Update()
    {
        //When camera reaches a certain height new grids will be placed to keep the game infinite
        if (cameraTransform.position.y > cameraHeight)
        {
            grid.CreateLevel(startPoint, endPoint);
            startPoint += height;
            endPoint += height;
            cameraHeight += height;
        }
    }
}