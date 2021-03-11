using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DestroyEverything : MonoBehaviour
{
    public float speed;
    public float waitBeforeDestroyingEverything;
    public GameManager gameManager;
    
    private const int Height = 10;
    private int position = 10;
    private ObjectPooler _objPooler;
    private bool _firstTileChunk = true;

    private void Start()
    {
        _objPooler = new ObjectPooler();  
    }

    private void Update()
    {
        StartCoroutine(StartMoving());
        if (transform.position.y >= position)
        {
            position += 10;
            BeginTheDestruction();
        }
    }
    
    //Starts moving after a short period.
    private IEnumerator StartMoving()
    {
        yield return new WaitForSeconds(waitBeforeDestroyingEverything);
        
        GetComponentInChildren<ParticleSystem>().Play();
        transform.Translate(0,1 * Time.deltaTime * speed,0);
    }

    //Destroy the level from bottom. Destroys whatever comes in it's way
    private void BeginTheDestruction()
    {
        var tileChunk = _objPooler.DequeObj();
        if (_firstTileChunk)
        {
            Destroy(tileChunk);
            _firstTileChunk = false;
            return;
        }
        tileChunk.SetActive(false);
        tileChunk.transform.position = new Vector2(0, gameManager.yPos + Height);
        gameManager.yPos += Height;
        _objPooler.EnqueueObj(tileChunk);
    }
}
