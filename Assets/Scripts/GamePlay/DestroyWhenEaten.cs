using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenEaten : MonoBehaviour
{
    //Should look like Pac-Man is eating those pallets. Can be used for other purposes
    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
