using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
   private void Start()
    {
        SpwanGrids();
    }

    private void SpwanGrids()
    {
        var tileGrid = (GameObject) Instantiate(Resources.Load("LevelGrids"));
        
        InstantiateTile(0, 0, tileGrid);
        
        Destroy(tileGrid);
    }
    
    private void InstantiateTile(int rows, int columns, GameObject referenceTile)
    {
        GameObject tile = Instantiate(referenceTile, transform);
    
        float posX = rows;
        float posY = columns;
                
        tile.transform.position = new Vector2(posX, posY);
    }
}
