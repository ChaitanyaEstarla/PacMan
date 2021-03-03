using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DestroyEverything : MonoBehaviour
{
    public float speed;
    public float waitBeforeDestroyingEveryting;
    
    private void Update()
    {
        StartCoroutine(DestroyOtherObjects());
    }
    
    //Destroy the level from bottom. Destroys whatever comes in it's trigger
    private IEnumerator DestroyOtherObjects()
    {
        yield return new WaitForSeconds(waitBeforeDestroyingEveryting);
        GetComponentInChildren<ParticleSystem>().Play();
        transform.Translate(0,1 * Time.deltaTime * speed,0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.gameObject.name);
        Destroy(other.gameObject);
    }
    
}
