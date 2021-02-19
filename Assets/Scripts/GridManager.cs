using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private bool decideTiles = true;
    
    void Start()
    {
        //CreateBase();
        CreateRoad();
        //CreatePellets();
    }

    private void CreateBase()
    { 
        GameObject referenceTile = (GameObject) Instantiate(Resources.Load("4 Square"));
        
        for (int row = -10; row < 10; row++)
        {
            for (int cols = -5; cols < 15; cols++)
            {
                InstantiateTile(row, cols, referenceTile);
            }
        }
        Destroy(referenceTile);
    }

    private void CreateRoad()
    {
        bool prevBuild = false;
        GameObject referenceTile = (GameObject) Instantiate(Resources.Load("WhiteBox"));
        
        for (int cols = 0; cols < 20; cols++)
        {
            
            for (int row = -10; row < 10; row++)
            {
                if (decideTiles && !prevBuild)
                {
                    InstantiateTile(row, cols, referenceTile);
                    
                }
                else if(!decideTiles)
                {
                    
                }
            }
            prevBuild = decideTiles;
            decideTiles  = (Random.value > 0.5f);
        }
        Destroy(referenceTile);
    }

    private void InstantiateTile(int rows, int columns, GameObject referenceTile)
    {
        GameObject tile = Instantiate(referenceTile, transform);
    
        float posX = rows;
        float posY = columns;
                
        tile.transform.position = new Vector2(posX, posY);
    }

    private void CreatePellets()
    {
        GameObject referenceTile = (GameObject) Instantiate(Resources.Load("Pellets"));
        
        for (int row = -10; row < 10; row++)
        {
            for (int cols = -5; cols < 15; cols++)
            {
                InstantiateTile(row, cols, referenceTile);
            }
        }
        Destroy(referenceTile);
    }
}
