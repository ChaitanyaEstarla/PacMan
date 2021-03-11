using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private bool _firstTileChunk = true;
    private const int Height = 10;
    
    public GameManager gameManager;
    
    private void Start()
    {
    }

    #region Instantiate Tiles
    public void SpawnGrids(int xPos, int yPos, bool deactivateChunk)
    {
        var tileGrid = (GameObject) Instantiate(Resources.Load("LevelGrid"));
        
        InstantiateAndPoolTile(xPos, yPos, tileGrid, deactivateChunk);
        
        Destroy(tileGrid);
    }
    
    //Created a function call making the code more cleaner for SpawnGrid. This instantiates each object tile in each chunk
    private void InstantiateAndPoolTile(int xPos, int yPos, GameObject referenceTile, bool deactivateChunk)
    {
        var tile = Instantiate(referenceTile, transform);
        
        //Add to List
        ObjectPooler.AddObj(tile);

        float posX = xPos;
        float posY = yPos;
                
        tile.transform.position = new Vector2(posX, posY);
        
        if (deactivateChunk) tile.SetActive(false);
    }
    #endregion

    //When world destroyer reaches a certain height it will call this member function to move the tile chunk at the top end of the list. This also updates the position of that gObject
    public void MoveTileChunk()
    {
        var tileChunk = ObjectPooler.RemoveObj();
        if (_firstTileChunk)
        {
            //Destroy the first one coz it has a border at the bottom
            Destroy(tileChunk);
            _firstTileChunk = false;
            return;
        }
        tileChunk.SetActive(false);
        tileChunk.transform.position = new Vector2(0, gameManager.yPos + Height);
        gameManager.yPos += Height;
        ObjectPooler.AddObj(tileChunk);
    }
}
