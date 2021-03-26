using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sue : MonoBehaviour
{
    private bool _isMoving;
    private Vector2 _currentPos, _nextPos;
    private Vector2 _checkSide;
    private Vector2 _currentPath;
    
    private const float TimeToMove = 0.3f;
    
    private PacmanMovement _pacManMovement;
    private GameObject _pacMan;
    private Sprite _currentSprite;
    
    public Sprite sueRight, sueLeft, sueUp, sueDown;
    

    private void OnEnable()
    {
        _currentPath = Vector2.left;
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
            TurnRight();
            StartCoroutine(MoveForward(_currentPath));
        }

        if (!_isMoving && !_pacManMovement.tileData[(Vector2) transform.position + _currentPath])
        {
            _currentPath = RetrieveRightSide();
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

    private void TurnRight()
    {
        if (_currentPath == (Vector2.right))
        {
            if (_pacManMovement.tileData[(Vector2) transform.position + (Vector2.down)])
            {
                _currentPath = Vector2.down;
                return;
            }
        }
        if (_currentPath == Vector2.left)
        {
            if (_pacManMovement.tileData[(Vector2) transform.position + (Vector2.up)])
            {
                _currentPath = Vector2.up;
                return;
            }
        }
        if (_currentPath == Vector2.up)
        {
            if (_pacManMovement.tileData[(Vector2) transform.position + (Vector2.right)])
                
            {
                _currentPath = Vector2.right;
                return;
            }   
        }
        if (_currentPath == Vector2.down)
        {
            if (_pacManMovement.tileData[(Vector2) transform.position + (Vector2.left)])
            {
                _currentPath = Vector2.left;
            }
        }
    }
    
    private Vector2 RetrieveRightSide()
    {
        if (_currentPath == (Vector2.right))
        {
            return Vector2.down;
        }
        if (_currentPath == Vector2.left)
        {
            return Vector2.up;
        }
        if (_currentPath == Vector2.up)
        {
            return Vector2.right;   
        }
        if (_currentPath == Vector2.down)
        {
            return Vector2.left;
        }
        else
        {
            return Vector2.left;
        }
    }

    private void ChangeSprite()
    {
        if (_currentPath == (Vector2.right))
        {
            _currentSprite = sueRight;
        }
        if (_currentPath == Vector2.left)
        {
            _currentSprite = sueLeft;
        }
        if (_currentPath == Vector2.up)
        {
            _currentSprite = sueUp;
        }
        if (_currentPath == Vector2.down)
        {
            _currentSprite = sueDown;
        }

        gameObject.GetComponent<SpriteRenderer>().sprite = _currentSprite;
    }
}
