using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
