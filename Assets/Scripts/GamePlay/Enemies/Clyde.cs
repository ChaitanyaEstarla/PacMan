using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Clyde : MonoBehaviour
{
    public List<Sprite> clydeSprites;

    private int _direction;
    private bool _directionToChoose;
    private bool _coroutineRunning;
    private bool _isMovingHorizontal;
    
    private const float TimeToMove = 0.3f;
    
    private Sprite _currentSprite;
    private PacmanMovement _pacManMovement;
    private GameObject _pacMan;
    
    private Vector2 _currentPos, _nextPos;
    private Vector2 _currentPath;
    
    private void Start()
    {
        _pacMan = GameObject.Find("Pacman");
        _pacManMovement = _pacMan.GetComponent<PacmanMovement>();
        _currentPath = Vector2.down;
    }

    private void Update()
    {
        if (!_coroutineRunning && _pacManMovement.tileData[(Vector2)transform.position + Vector2.down])
        {
            if(_isMovingHorizontal) _isMovingHorizontal = false;
            _currentPath = Vector2.down;
            StartCoroutine(Move(_currentPath));
        }
        if(!_coroutineRunning && !_pacManMovement.tileData[(Vector2)transform.position + Vector2.down])
        {
            if (!_isMovingHorizontal)
            {
                ChooseDirection();
                _isMovingHorizontal = true;
            }
            
            if(_pacManMovement.tileData[(Vector2)transform.position + _currentPath])  StartCoroutine(Move(_currentPath));
            
            if (!_pacManMovement.tileData[(Vector2) transform.position + _currentPath])
            {
                _isMovingHorizontal = false;
            }
        }
    }
    
    private IEnumerator Move(Vector2 direction)
    {
        _coroutineRunning = true;
        
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

        _coroutineRunning = false;
    }
    
    //Sprite will change according to the direction Blinky is moving in
    private void ChangeSprite()
    {
        if (_currentPath == (Vector2.right))
        {
            _currentSprite = clydeSprites[0];
        }
        if (_currentPath == Vector2.left)
        {
            _currentSprite = clydeSprites[3];
        }
        if (_currentPath == Vector2.up)
        {
            _currentSprite = clydeSprites[1];
        }
        if (_currentPath == Vector2.down)
        {
            _currentSprite = clydeSprites[2];
        }

        gameObject.GetComponent<SpriteRenderer>().sprite = _currentSprite;
    }

    //If clyde reaches a wall he will randomly turn towards other available routes
    private void ChooseDirection()
    {
        _directionToChoose = Random.value > 0.5;
        _direction = _directionToChoose ? 1 : -1;
        _currentPath = Vector2.right * _direction;
    }
}
