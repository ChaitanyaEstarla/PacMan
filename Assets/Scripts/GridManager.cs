using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    const int width = 20;
    const int height = 20;
    private const int horizontalAxisPoints = 10;

    bool[,] referenceGrid = new bool[height, width];
    
    void Start()
    {
        //CreateLevel();
    }

    //Place tiles on the Grid generated
    public void CreateLevel(int startPoint, int endPoint)
    {
        //CAlled to generate the 2D Array for level generation
        ReferenceGrid();
        
        GameObject roadTile = (GameObject) Instantiate(Resources.Load("WhiteBox"));
        GameObject wallTile = (GameObject) Instantiate(Resources.Load("BlackBG"));
        GameObject pellets = (GameObject) Instantiate(Resources.Load("Pellets"));

        for (int cols = startPoint, i = 0; cols < endPoint; cols++, i++)
        {
            for (int row = -horizontalAxisPoints, j = 0; row < horizontalAxisPoints; row++, j++)
            {
                if (referenceGrid[i,j])
                {
                    InstantiateTile(row, cols, roadTile);
                    InstantiateTile(row, cols, pellets);
                }

                if (!referenceGrid[i, j])
                {
                    InstantiateTile(row, cols, wallTile);
                }
            }
        }

        Destroy(roadTile);
        Destroy(wallTile);
        Destroy(pellets);
    }

    //Instantiate and place asset at the position
    private void InstantiateTile(int rows, int columns, GameObject referenceTile)
    {
        GameObject tile = Instantiate(referenceTile, transform);
    
        float posX = rows;
        float posY = columns;
                
        tile.transform.position = new Vector2(posX, posY);
    }

    //Generates a 2D boolean Array for which will be used for creating levels
    private void ReferenceGrid()
    {
        bool road = true;
        int limit = 0; //Limited the creation of connector type columns so it doesn't look weird
        bool prevColumn = false; //needed this for creating a proper grid

        //Creating grid 
        for (int i = 0; i < height; i++)
        {
            if (road)
            {
                for (int j = 1; j < width-1; j++)
                {
                    referenceGrid[i, j] = road;
                }
            }
            else
            {
                //If previous grid row was a connector then this if should be selected because current grid needs to be same as previous
                if (!prevColumn)
                {
                    for (int j = 1; j < width-1; j++)
                    {
                        referenceGrid[i, j] = referenceGrid[i - 1, j];
                    }
                    limit++;
                }
                else
                {
                    int j = 1;
                    while (j < width-1)
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
            if (road || i == height - 2)
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
    }
}
