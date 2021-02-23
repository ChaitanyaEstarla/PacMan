using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    const int width = 20;
    const int height = 10;

    bool[,] referenceGrid = new bool[height, width];
    
    void Start()
    {
        ReferenceGrid();
        CreateLevel();
    }

    private void CreateLevel()
    {
        bool prevBuild = false;
        
        GameObject roadTile = (GameObject) Instantiate(Resources.Load("WhiteBox"));
        GameObject wallTile = (GameObject) Instantiate(Resources.Load("BlackBG"));
        GameObject pellets = (GameObject) Instantiate(Resources.Load("Pellets"));

        for (int cols = 0, i = 0; cols < height; cols++, i++)
        {

            for (int row = -10, j = 0; row < height; row++, j++)
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

    private void InstantiateTile(int rows, int columns, GameObject referenceTile)
    {
        GameObject tile = Instantiate(referenceTile, transform);
    
        float posX = rows;
        float posY = columns;
                
        tile.transform.position = new Vector2(posX, posY);
    }

    private void ReferenceGrid()
    {
        bool road = true;
        int limit = 0;
        bool prevColumn = false;

        for (int i = 0; i < height; i++)
        {
            if (road)
            {
                for (int j = 0; j < width; j++)
                {
                    referenceGrid[i, j] = road;
                }
            }
            else
            {
                if (!prevColumn)
                {
                    for (int j = 0; j < width; j++)
                    {
                        referenceGrid[i, j] = referenceGrid[i - 1, j];
                    }
                    limit++;
                }
                else
                {
                    int j = 0;
                    while (j < width)
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

            if (road)
            {
                prevColumn = road;
                road = false;
            }
            else if (limit > 2)
            {
                prevColumn = road;
                road = true;
                limit = 0;
                Debug.Log("it was here");
            }
            else
            {
                prevColumn = road;
                road = Random.value > 0.5f;
            }
        }
    }
}
