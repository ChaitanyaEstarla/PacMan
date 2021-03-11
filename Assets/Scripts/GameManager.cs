using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class GameManager : MonoBehaviour
{
    /*
     Old Code
    private int _startPoint;
    private int _endPoint = 10;
    private int _cameraHeight = 20; //Detecting the camera transform to generate further levels
    public GameObject pacMan;
    public Transform cameraTransform;
    */
    
    // Default tile chunks generated at the beginning of the game
    public int defaultRoadChunks;
    public GridManager grid; 
    public int xPos, yPos;
    
    private const int Height = 10;  //Default height I've chosen right now. This is used for level generation
    //private ObjectPooler _objectPooler;
    private bool _firstIteration;
    private bool _deactivateChunk;
    
    private void Start()
    {
        //_objectPooler = new ObjectPooler();
        for (var i = 0; i < defaultRoadChunks; i++)
        {
            yPos += Height;
            grid.SpawnGrids(xPos,yPos, _deactivateChunk);
            if (i >= 4) _deactivateChunk = true;
        }
    }
    
    
    
    /*
    private void Start()
    {
        //Old Code | Tiles were direct children of Grid Manager
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
        //Old Code | Tiles were direct children of Grid Manager
        //When camera reaches a certain height new grids will be placed to keep the game infinite
        if (!(cameraTransform.position.y > _cameraHeight)) return;
        grid.CreateLevel(_startPoint, _endPoint);
        _startPoint += Height;
        _endPoint += Height;
        _cameraHeight += Height;
    }
    */
}