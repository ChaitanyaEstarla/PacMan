using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMovement : MonoBehaviour
{
    private bool isMoving;
    private float timeToMove = 0.2f;
    private Vector2 currentPos, nextPos;
    private Rigidbody2D pacman;
    public float speed;

    void Start()
    {
        //pacman = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector2.left));
        }
        if (Input.GetKey(KeyCode.D) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector2.right));
        }
        if (Input.GetKey(KeyCode.W) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector2.up));
        }
        if (Input.GetKey(KeyCode.S) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector2.down));
        }
    }

    private IEnumerator MovePlayer(Vector2 direction)
    {
        isMoving = true;

        float elapsedTime = 0;
        
        currentPos = transform.position;
        nextPos = currentPos + direction;

        while (elapsedTime < timeToMove)
        {
            //pacman.MovePosition(nextPos * Time.deltaTime * speed);
            transform.position = Vector2.Lerp(currentPos, nextPos, elapsedTime / timeToMove);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = nextPos;

        isMoving = false;
    }
}
