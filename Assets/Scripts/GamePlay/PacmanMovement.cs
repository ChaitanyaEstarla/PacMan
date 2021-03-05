using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMovement : MonoBehaviour
{
    private bool _isMoving;
    private const float TimeToMove = 0.2f;
    private Vector2 _currentPos, _nextPos;
    public GridManager grid;
    
    //public float speed;

    void Update()    
    {
        if (Input.GetKey(KeyCode.A) && !_isMoving && grid.tileData[(Vector2)transform.position + Vector2.left])  StartCoroutine(MovePlayerTest(Vector2.left , 180));
        if (Input.GetKey(KeyCode.D) && !_isMoving && grid.tileData[(Vector2)transform.position + Vector2.right]) StartCoroutine(MovePlayerTest(Vector2.right, 0));
        if (Input.GetKey(KeyCode.W) && !_isMoving && grid.tileData[(Vector2)transform.position + Vector2.up])    StartCoroutine(MovePlayerTest(Vector2.up   , 90));
        if (Input.GetKey(KeyCode.S) && !_isMoving && grid.tileData[(Vector2)transform.position + Vector2.down])  StartCoroutine(MovePlayerTest(Vector2.down , -90));
    }

    private IEnumerator MovePlayerTest(Vector2 direction, int angle)
    {
        _isMoving = true;

        float elapsedTime = 0;
        
        _currentPos = transform.position;
        _nextPos = _currentPos + direction;
        
        gameObject.transform.eulerAngles = Vector3.forward * angle;
        
        while (elapsedTime < TimeToMove)
        {
            transform.position = Vector2.Lerp(_currentPos, _nextPos, elapsedTime/TimeToMove);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = _nextPos;
        
        _isMoving = false;
    }
}