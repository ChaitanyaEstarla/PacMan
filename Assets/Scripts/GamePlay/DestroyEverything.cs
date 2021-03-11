using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DestroyEverything : MonoBehaviour
{
    public float speed;
    public float waitBeforeDestroyingEverything;
    public GridManager gridManager;
    public PacmanMovement pacManMovement;

    private int _position = 10;

    private void Start()
    {
    }

    private void Update()
    {
        StartCoroutine(StartMoving());
        if (transform.position.y >= _position)
        {
            _position += 10;
            gridManager.MoveTileChunk();
            pacManMovement.UpdateDictionary();
        }
    }
    
    //Starts moving after a short period.
    private IEnumerator StartMoving()
    {
        yield return new WaitForSeconds(waitBeforeDestroyingEverything);
        
        GetComponentInChildren<ParticleSystem>().Play();
        transform.Translate(0,1 * Time.deltaTime * speed,0);
        
    }
}
