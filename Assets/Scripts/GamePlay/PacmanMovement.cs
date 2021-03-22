using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class PacmanMovement : MonoBehaviour
{
    private bool _isMoving;
    private const float TimeToMove = 0.2f;
    private Vector2 _currentPos, _nextPos;
    private const int VectorX = 10;
    private int _vectorY;
    private bool _firstTileChunk = true;

    private const int Height = 10;
    
    public Dictionary<Vector2, bool> tileData = new Dictionary<Vector2, bool>();

    public GameManager gameManager;

    private void Update()    
    {
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))  && !_isMoving && tileData[(Vector2)transform.position + Vector2.left])  { StartCoroutine(MovePlayerTest(Vector2.left , 180)); }
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && !_isMoving && tileData[(Vector2)transform.position + Vector2.right]) { StartCoroutine(MovePlayerTest(Vector2.right, 0)); }
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))    && !_isMoving && tileData[(Vector2)transform.position + Vector2.up])    { StartCoroutine(MovePlayerTest(Vector2.up   , 90)); }
        if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))  && !_isMoving && tileData[(Vector2)transform.position + Vector2.down])  { StartCoroutine(MovePlayerTest(Vector2.down , -90)); }
    } 

    #region Pac-Man Movement
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
    #endregion
    
    //Need to update dictionary when World Destroyer destroys or sends chunk up deactivated
    public void UpdateDictionary()
    {
        var newYpos = gameManager.yPos;
        for (var cols = _vectorY; cols < _vectorY+Height; cols++,newYpos++)
        {
            for (var rows = -VectorX; rows < VectorX; rows++)
            {
                var tempVec = new Vector2(rows, cols);
                var tileValue = tileData[tempVec];
                
                tileData.Remove(tempVec);
                
                if (_firstTileChunk) continue;
                
                tileData.Add(new Vector2(rows, newYpos), tileValue);
            }
        }

        if(_firstTileChunk) _firstTileChunk = false;
        gameManager.yPos += Height;
        _vectorY += Height;
    }
}

#region Old Code
//Old Code using Physics System
/*public class PacmanManager : MonoBehaviour
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
}*/
#endregion
