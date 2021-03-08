using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DestroyEverything : MonoBehaviour
{
    public float speed;
    public float waitBeforeDestroyingEverything;

    private void Start()
    {
        
    }

    private void Update()
    {
        StartCoroutine(StartMoving());
        if (transform.position.y > 0)
        {
            StartCoroutine(BeginTheDestruction());
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
    private IEnumerator BeginTheDestruction()
    {
        yield return null;
    }
}
