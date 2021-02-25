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

    public void CreateLevel(int startPoint, int endPoint)
    {
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
                for (int j = 1; j < width-1; j++)
                {
                    referenceGrid[i, j] = road;
                }
            }
            else
            {
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

            if (road || i == height - 2)
            {
                prevColumn = road;
                road = false;
            }
            else if (limit > 2)
            {
                prevColumn = road;
                road = true;
                limit = 0;
            }
            else
            {
                prevColumn = road;
                road = Random.value > 0.5f;
            }
        }
    }
}
