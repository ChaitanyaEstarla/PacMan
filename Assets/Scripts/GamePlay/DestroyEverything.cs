using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DestroyEverything : MonoBehaviour
{
    public float speed;
    public float waitBeforeDestroyingEverything;
    
    private void Update()
    {
        StartCoroutine(DestroyOtherObjects());
    }
    
    //Destroy the level from bottom. Destroys whatever comes in it's trigger
    private IEnumerator DestroyOtherObjects()
    {
        yield return new WaitForSeconds(waitBeforeDestroyingEverything);
        GetComponentInChildren<ParticleSystem>().Play();
        transform.Translate(0,1 * Time.deltaTime * speed,0);
    }
}
