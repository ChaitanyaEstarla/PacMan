using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private void Start()
    {
    }

    public void SpawnGrids(int xPos, int yPos)
    {
        var tileGrid = (GameObject) Instantiate(Resources.Load("LevelGrid"));
        
        InstantiateTile(xPos, yPos, tileGrid);
        
        Destroy(tileGrid);
    }
    
    private void InstantiateTile(int xPos, int yPos, GameObject referenceTile)
    {
        var tile = Instantiate(referenceTile, transform);
    
        float posX = xPos;
        float posY = yPos;
                
        tile.transform.position = new Vector2(posX, posY);
    }
}
