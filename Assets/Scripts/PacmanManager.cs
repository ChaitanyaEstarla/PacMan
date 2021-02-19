using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PacmanManager : MonoBehaviour
{
    public float speed = 0f;
    
    private bool movePlayer = false;
    private int direction = 0;
    private int angle = 0;
    private Rigidbody2D pacman;

    private void Start()
    {
        pacman = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            movePlayer = true;
            direction = 1;
            angle = 180;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            movePlayer = true;
            direction = 2;
            angle = 0;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            movePlayer = true;
            direction = 3;
            angle = 90;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            movePlayer = true;
            direction = 4;
            angle = -90;
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            movePlayer = false;
            direction = 0;
        }
    }

    void FixedUpdate()
    {
        if(movePlayer)
        {
            MoveInDirection();
            gameObject.GetComponent<Animator>().enabled = true;
        }
        
        if (!movePlayer)
        {
            gameObject.GetComponent<Animator>().enabled = false;
        }
    }
    
    private void MoveInDirection()
    {
        switch (direction)
        {
            case 1:
                pacman.MovePosition(Vector2.right * Time.deltaTime * speed);
                gameObject.transform.eulerAngles = Vector3.forward * angle;
                break;
            case 2:
                pacman.MovePosition(Vector2.left * Time.deltaTime * speed);
                gameObject.transform.eulerAngles = Vector3.forward * angle;
                break;
            case 3:
                gameObject.transform.position += Vector3.up * Time.deltaTime * speed;
                gameObject.transform.eulerAngles = Vector3.forward * angle;
                break;
            case 4:
                gameObject.transform.position += Vector3.down * Time.deltaTime * speed;
                gameObject.transform.eulerAngles = Vector3.forward * angle;
                break;
        }
    }

    public void StopPlayer()
    {
        movePlayer = false;
    }
}