using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenEaten : MonoBehaviour
{
    public GameObject pacMan;

    private void Start()
    {
        pacMan = GameObject.Find("Pacman");
    }

    //Should look like Pac-Man is eating those pallets. Can be used for other purposes
    private void Update()
    {
        if (pacMan.transform.position == gameObject.transform.position)
        {
            Destroy(gameObject);
        }
    }
}
