using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private int rows = 20;
    private int columns = 20;
    private float tileCount = 1;
    
    void Start()
    {
        CreateBase();
        CreateRoad();
        CreatePellets();
    }

    private void CreateBase()
    {
        GameObject referenceTile = (GameObject) Instantiate(Resources.Load("BlackBG"));
        
        for (int row = -10; row < 10; row++)
        {
            for (int cols = -5; cols < 15; cols++)
            {
                GameObject tile = (GameObject) Instantiate(referenceTile, transform);

                float posX = row;
                float posY = cols;
                
                tile.transform.position = new Vector2(posX, posY);
            }
        }
        Destroy(referenceTile);
    }

    private void CreateRoad()
    {
        GameObject referenceTile = (GameObject) Instantiate(Resources.Load("WhiteBox"));
        
        for (int row = -10; row < 10; row++)
        {
            for (int cols = -5; cols < 15; cols++)
            {
                GameObject tile = (GameObject) Instantiate(referenceTile, transform);

                float posX = row;
                float posY = cols;
                
                tile.transform.position = new Vector2(posX, posY);
            }
        }
        Destroy(referenceTile);
    }
    
    private void CreatePellets()
    {
        GameObject referenceTile = (GameObject) Instantiate(Resources.Load("Pellets"));
        
        for (int row = -10; row < 10; row++)
        {
            for (int cols = -5; cols < 15; cols++)
            {
                GameObject tile = (GameObject) Instantiate(referenceTile, transform);

                float posX = row;
                float posY = cols;
                
                tile.transform.position = new Vector2(posX, posY);
            }
        }
        Destroy(referenceTile);
    }

    void Update()
    {
        
    }
}
