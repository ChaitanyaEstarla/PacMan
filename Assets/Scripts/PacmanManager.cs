using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanManager : MonoBehaviour
{
    public float speed = 0f;
    private bool movePlayer = false;
    private int direction = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            movePlayer = true;
            direction = 1;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            movePlayer = true;
            direction = 2;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            movePlayer = true;
            direction = 3;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            movePlayer = true;
            direction = 4;
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            movePlayer = false;
            direction = 0;
        }
        if(movePlayer == true)
        {
            MoveInDirection();
        }
    }
    
    private void MoveInDirection()
    {
        switch (direction)
        {
            case 1:
                gameObject.transform.position += Vector3.left * Time.deltaTime * speed;
                break;
            case 2:
                gameObject.transform.position += Vector3.right * Time.deltaTime * speed;
                break;
            case 3:
                gameObject.transform.position += Vector3.up * Time.deltaTime * speed;
                break;
            case 4:
                gameObject.transform.position += Vector3.down * Time.deltaTime * speed;
                break;
        }
    }
}