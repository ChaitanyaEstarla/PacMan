﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class GameManager : MonoBehaviour
{
    
    //Default tile chunks generated at the beginning of the game
    public int defaultRoadChunks;
    
    private int _startPoint;
    private int _endPoint = 10;
    private const int Height = 10;  //Default height I've chosen right now. This is used for level generation
    private int _cameraHeight = 20; //Detecting the camera transform to generate further levels
    public GameObject pacMan;

    public TileGenerator grid;
    public Transform cameraTransform;
    
    void Start()
    {
        //Initial gird generated at the beginning of the game
        for (int i = 0; i < defaultRoadChunks; i++)
        {
            grid.CreateLevel(_startPoint, _endPoint);
            _startPoint += Height;
            _endPoint += Height;
        }
        pacMan.SetActive(true);
    }

    private void Update()
    {
        //When camera reaches a certain height new grids will be placed to keep the game infinite
        if (!(cameraTransform.position.y > _cameraHeight)) return;
        grid.CreateLevel(_startPoint, _endPoint);
        _startPoint += Height;
        _endPoint += Height;
        _cameraHeight += Height;
    }
}