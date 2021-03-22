using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TileGenerator : MonoBehaviour
{
    private const int Width = 20;
    private const int Height = 10;
    private const int HorizontalAxisPoints = 10;
    
    private static bool _firstIteration = true;
    private static int _startPointY;
    private static int _endPointY = 10;
    
    private GameObject _pacMan;
    private PacmanMovement _pacManMovementData;
    
    public bool[,] referenceGrid = new bool[Height, Width];

    private readonly List<GameObject> _pelletList = new List<GameObject>();

    private void OnEnable()
    {
        //ReEnabling pellets after the Tile chunk is places 
        if (_pelletList == null) return;
        foreach (var pellet in _pelletList)
        {
            if (!pellet.activeSelf)
            {
                pellet.SetActive(true);
            }
        }
    }

    private void Start()
    {
        _pacMan = GameObject.Find("Pacman");
        _pacManMovementData = _pacMan.GetComponent<PacmanMovement>();
        _pacManMovementData = _pacMan.GetComponent<PacmanMovement>();

        CreateLevel();
        _startPointY = _endPointY;
        _endPointY += Height;
    }

    #region Tile Chunk Generation
    //Place tiles on the Grid generated
    private void CreateLevel()
    {
        //Called to generate the 2D Array for level generation
        ReferenceGrid();
        
        
        var roadTile = (GameObject) Instantiate(Resources.Load("WhiteBox"));
        var wallTile = (GameObject) Instantiate(Resources.Load("BlackBG"));
        var pellets  = (GameObject) Instantiate(Resources.Load("Pellets"));

        for (int cols = _startPointY, i = 0; cols < _endPointY; cols++, i++)
        {
            for (int row = -HorizontalAxisPoints, j = 0; row < HorizontalAxisPoints; row++, j++)
            {
                
                if (referenceGrid[i,j])
                {
                    InstantiateTile(row, cols, roadTile);
                    if (row == 0 && cols == 1)
                    {
                        //Debug.Log("Skipped Pellet here ("+row+","+cols+")");                        
                    }   
                    else
                    {
                        InstantiatePellets(row, cols, pellets);
                    }
                    
                }

                if (!referenceGrid[i, j])
                {
                    InstantiateTile(row, cols, wallTile);
                }
                
                _pacManMovementData.tileData.Add(new Vector2(row,cols), referenceGrid[i,j]);
            }
        }

        Destroy(roadTile);
        Destroy(wallTile);
        Destroy(pellets);
    }
    
    private void InstantiatePellets(int xPos, int yPos, GameObject referenceTile)
    {
        var tile = Instantiate(referenceTile, transform);
        
        //Add to pellet list. List will be used to reEnable these gObjects later on
        _pelletList.Add(tile);
        
        float posX = xPos;
        float posY = yPos;
                
        tile.transform.position = new Vector2(posX, posY);
    }

    //Instantiate and place asset at the position
    private void InstantiateTile(int rows, int columns, GameObject referenceTile)
    {
        var tile = Instantiate(referenceTile, transform);
    
        float posX = rows;
        float posY = columns;
                
        tile.transform.position = new Vector2(posX, posY);
    }

    //Generates a 2D boolean Array for which will be used for creating levels
    private void ReferenceGrid()
    {
        var road = true;
        var limit = 0;          //Limited the creation of connector type columns so the grid doesn't look weird
        var prevColumn = false; //needed this for creating a proper grid

        //Creating grid 
        for (var i = _firstIteration ? 1:0; i < Height; i++)
        {
            if (road)
            {
                for (int j = 1; j < Width-1; j++)
                {
                    referenceGrid[i, j] = road;
                }
            }
            else
            {
                //If previous grid row was a connector then this if should be selected because current grid needs to be same as previous
                if (!prevColumn)
                {
                    for (var j = 1; j < Width-1; j++)
                    {
                        referenceGrid[i, j] = referenceGrid[i - 1, j];
                    }
                    limit++;
                }
                else
                {
                    var j = 1;
                    while (j < Width-1)
                    {
                        referenceGrid[i, j] = (Random.value > 0.5f);
                        if (j == 0)
                        {
                            j++;
                            continue;
                        }

                        if (referenceGrid[i, j - 1] && referenceGrid[i, j])
                        {
                            referenceGrid[i, j] = false;
                        }
                        j++;
                    }
                }
            }
            
            //If previous row was a full road then next one needs to be connectors
            if (road || i == Height - 2)
            {
                prevColumn = road;
                road = false;
            }//Last 2 will always be connector type columns. This helps with connecting the grids together
            else if (limit > 2)
            {
                prevColumn = road;
                road = true;
                limit = 0;
            }//If previous one is a connector type grid then the next one can be random
            else
            {
                prevColumn = road;
                road = Random.value > 0.5f;
            }
        }

        if(_firstIteration) _firstIteration = false;
    }
    #endregion
}
