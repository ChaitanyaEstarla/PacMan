using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEverything : MonoBehaviour
{
    public float speed = 0.1f;
    
    private void Update()
    {
        StartCoroutine(DestroyOtherObjects());
    }
    
    private IEnumerator DestroyOtherObjects()
    {
        yield return new WaitForSeconds(1);
        
        transform.Translate(0,1 * Time.deltaTime * speed,0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.gameObject.name);
        Destroy(other.gameObject);
    }
    
}
