using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private ObjectPooler _objPooler = new ObjectPooler();
    
    private void Start()
    {
    }

    public void SpawnGrids(int xPos, int yPos, bool deactivateChunk)
    {
        var tileGrid = (GameObject) Instantiate(Resources.Load("LevelGrid"));
        
        InstantiateAndPoolTile(xPos, yPos, tileGrid, deactivateChunk);
        
        Destroy(tileGrid);
    }
    
    private void InstantiateAndPoolTile(int xPos, int yPos, GameObject referenceTile, bool deactivateChunk)
    {
        var tile = Instantiate(referenceTile, transform);
        
        //Enqueue
        _objPooler.EnqueueObj(tile);

        if (deactivateChunk) tile.SetActive(false);

        float posX = xPos;
        float posY = yPos;
                
        tile.transform.position = new Vector2(posX, posY);
    }
}
