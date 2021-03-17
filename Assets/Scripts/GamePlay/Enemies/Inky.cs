using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Inky : MonoBehaviour
{
    private int _direction;
    private bool _directionToChoose;
    private bool _isMoving;
    private Vector2 _currentPos, _nextPos;
    private Vector2 _checkSide;
    private Vector2 _currentPath;
    
    private const float TimeToMove = 0.5f;
    
    private PacmanMovement _pacManMovement;
    private GameObject _pacMan;
    private Sprite _currentSprite;
    
    public Sprite inkyRight, inkyLeft, inkyUp, inkyDown;
    

    private void OnEnable()
    {
        _directionToChoose = Random.value> 0.5f;
        _direction = _directionToChoose ? 1:-1;
        _currentPath = Vector2.right;
    }

    private void Start()
    {
        _pacMan = GameObject.Find("Pacman");
        _pacManMovement = _pacMan.GetComponent<PacmanMovement>();
    }

    private void Update()
    {
        if (!_isMoving && _pacManMovement.tileData[(Vector2) transform.position + _currentPath])
        {
            TurnLeft();
            StartCoroutine(MoveForward(_currentPath));
        }

        if (!_isMoving && !_pacManMovement.tileData[(Vector2) transform.position + _currentPath])
        {
            _currentPath = RetrieveLeftSide();
            StartCoroutine(MoveForward(_currentPath));
        }
    }
    
    private IEnumerator MoveForward(Vector2 direction)
    {
        _isMoving = true;
        
        float elapsedTime = 0;
        
        ChangeSprite();
        
        _currentPos = transform.position;
        _nextPos = _currentPos + direction;
        
        while (elapsedTime < TimeToMove)
        {
            transform.position = Vector2.Lerp(_currentPos, _nextPos, elapsedTime/TimeToMove);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = _nextPos;

        _isMoving = false;
    }

    private void TurnLeft()
    {
        if (_currentPath == (Vector2.right))
        {
            if (_pacManMovement.tileData[(Vector2) transform.position + (Vector2.up)])
            {
                _currentPath = Vector2.up;
                return;
            }
        }
        if (_currentPath == Vector2.left)
        {
            if (_pacManMovement.tileData[(Vector2) transform.position + (Vector2.down)])
            {
                _currentPath = Vector2.down;
                return;
            }
        }
        if (_currentPath == Vector2.up)
        {
            if (_pacManMovement.tileData[(Vector2) transform.position + (Vector2.left)])
                
            {
                _currentPath = Vector2.left;
                return;
            }   
        }
        if (_currentPath == Vector2.down)
        {
            if (_pacManMovement.tileData[(Vector2) transform.position + (Vector2.right)])
            {
                _currentPath = Vector2.right;
            }
        }
    }
    
    private Vector2 RetrieveLeftSide()
    {
        if (_currentPath == (Vector2.right))
        {
            return Vector2.up;
        }
        if (_currentPath == Vector2.left)
        {
            return Vector2.down;
        }
        if (_currentPath == Vector2.up)
        {
            return Vector2.left;   
        }
        if (_currentPath == Vector2.down)
        {
            return Vector2.right;
        }
        else
        {
            return Vector2.right;
        }
    }

    private void ChangeSprite()
    {
        if (_currentPath == (Vector2.right))
        {
            _currentSprite = inkyRight;
        }
        if (_currentPath == Vector2.left)
        {
            _currentSprite = inkyLeft;
        }
        if (_currentPath == Vector2.up)
        {
            _currentSprite = inkyUp;
        }
        if (_currentPath == Vector2.down)
        {
            _currentSprite = inkyDown;
        }

        gameObject.GetComponent<SpriteRenderer>().sprite = _currentSprite;
    }
}
