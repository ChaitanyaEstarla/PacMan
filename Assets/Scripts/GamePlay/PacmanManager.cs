using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.WSA;

public class PacmanManager : MonoBehaviour
{
    //Pac - Man's speed
    public float speed = 0f;
    
    //public CircleCollider2D pacmanCollider;
    private bool movePlayer = false;
    private int direction = 0;
    private int angle = 0;
    private Rigidbody2D pacman;
    
    private int layerMask = 1 << 11;

    private void Start()
    {
        pacman = gameObject.GetComponent<Rigidbody2D>();
        //layerMask = ~layerMask;
    }

    void Update()
    {
        RaycastHit2D rayRight = Physics2D.Raycast(transform.position, Vector2.right,0.5f, layerMask);
        Debug.DrawRay(transform.position, Vector3.right * 0.55f, Color.magenta);
        
        RaycastHit2D rayUp = Physics2D.Raycast(transform.position, Vector2.up,0.5f, layerMask);
        Debug.DrawRay(transform.position, Vector3.up * 0.55f, Color.magenta);
        
        // RaycastHit2D rayUp = Physics2D.Raycast(transform.position, Vector2.down,0.5f, layerMask);
        // Debug.DrawRay(transform.position, Vector3.up * 0.55f, Color.magenta);

        if(rayRight)
        {
            Debug.Log("Hit Right " + rayRight.collider.name);
        }
        if(rayUp)
        {
            Debug.Log("Hit Up " + rayUp.collider.name);
        }

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
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) && !rayUp)
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
            MoveInDirection();                                   //Since we are moving a physics body. It should be in FixedUpdate
            gameObject.GetComponent<Animator>().enabled = true;
        }
        
        if (!movePlayer)
        {
            gameObject.GetComponent<Animator>().enabled = false;
        }
    }
    
    //Move GameObject in X & Y plane
    private void MoveInDirection()
    {
        switch (direction)
        {
            case 1:
                pacman.MovePosition((Vector2)gameObject.transform.position + Vector2.left * Time.deltaTime * speed);
                gameObject.transform.eulerAngles = Vector3.forward * angle;
                break;
            case 2:
                pacman.MovePosition((Vector2)gameObject.transform.position + Vector2.right * Time.deltaTime * speed);
                gameObject.transform.eulerAngles = Vector3.forward * angle;
                break;
            case 3:
                pacman.MovePosition((Vector2)gameObject.transform.position + Vector2.up * Time.deltaTime * speed);
                gameObject.transform.eulerAngles = Vector3.forward * angle;
                break;
            case 4:
                
                pacman.MovePosition((Vector2)gameObject.transform.position + Vector2.down * Time.deltaTime * speed);
                gameObject.transform.eulerAngles = Vector3.forward * angle;
                break;
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Gizmos.color = new Color(1, 0, 0, 0.5f);
        // Gizmos.DrawCube(transform.position, new Vector3(0.99f, 0.99f, 0));
    }
}