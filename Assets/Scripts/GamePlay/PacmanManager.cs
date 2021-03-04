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
    
    private bool _movePlayer = false;
    private int _direction = 0;
    private int _angle = 0;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _movePlayer = true;
            _direction = 1;
            _angle = 180;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _movePlayer = true;
            _direction = 2;
            _angle = 0;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            _movePlayer = true;
            _direction = 3;
            _angle = 90;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            _movePlayer = true;
            _direction = 4;
            _angle = -90;
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            _movePlayer = false;
            _direction = 0;
        }
    }

    void FixedUpdate()
    {
        if(_movePlayer)
        {
            MoveInDirection();                                   //Since we are moving a physics body. It should be in FixedUpdate
            gameObject.GetComponent<Animator>().enabled = true;
        }
        
        if (!_movePlayer)
        {
            gameObject.GetComponent<Animator>().enabled = false;
        }
    }
    
    //Move GameObject in X & Y plane
    private void MoveInDirection()
    {
        switch (_direction)
        {
            case 1:
                //pacman.MovePosition((Vector2)gameObject.transform.position + Vector2.left * Time.deltaTime * speed);
                gameObject.transform.eulerAngles = Vector3.forward * _angle;
                break;
            case 2:
                //pacman.MovePosition((Vector2)gameObject.transform.position + Vector2.right * Time.deltaTime * speed);
                gameObject.transform.eulerAngles = Vector3.forward * _angle;
                break;
            case 3:
                //pacman.MovePosition((Vector2)gameObject.transform.position + Vector2.up * Time.deltaTime * speed);
                gameObject.transform.eulerAngles = Vector3.forward * _angle;
                break;
            case 4:
                
                //pacman.MovePosition((Vector2)gameObject.transform.position + Vector2.down * Time.deltaTime * speed);
                gameObject.transform.eulerAngles = Vector3.forward * _angle;
                break;
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Gizmos.color = new Color(1, 0, 0, 0.5f);
        // Gizmos.DrawCube(transform.position, new Vector3(0.99f, 0.99f, 0));
    }
}