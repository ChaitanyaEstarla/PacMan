using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler
{
    private static Queue<GameObject> _tileChunk = new Queue<GameObject>();
    
    public void EnqueueObj(GameObject tileChunk)
    {
        _tileChunk.Enqueue(tileChunk);
    }

    public GameObject DequeObj()
    {
        return _tileChunk.Dequeue();
    } 
}
