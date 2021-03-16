using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public static class ObjectPooler
{
    private static readonly List<GameObject> TileChunk = new List<GameObject>();
    
    //Add gObject to list
    public static void AddObj(GameObject tileChunk)
    {
        TileChunk.Add(tileChunk);
    }

    //Remove gObject from list. Also returns it
    public static GameObject RemoveObj()
    {
        var tempGameObj = TileChunk[0];
        TileChunk.RemoveAt(0);
        return tempGameObj;
    }

    //Will be called by camera script when Pac-Man reaches a certain height to ensure the infinite level 
    public static void SetGameObjectActive()
    {
        for(var index = 0; index < TileChunk.Count; index++)
        {
            if (TileChunk[index].activeSelf) continue;
            TileChunk[index].SetActive(true);
            break;
        }
    }
}
