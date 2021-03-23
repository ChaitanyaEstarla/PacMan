using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Blinky : MonoBehaviour
{
    public List<Sprite> blinkySprites;
    private readonly List<Vector2> _availableDirections = new List<Vector2>();
    
    private int _direction;
    private bool _coroutineRunning;
    
    private const float TimeToMove = 0.3f;
    
    private Vector2 _currentPos, _nextPos;
    private Vector2 _currentPath;
    
    private Sprite _currentSprite;
    private PacmanMovement _pacManMovement;
    private GameObject _pacMan;
    
    private void Start()
    {
        _currentPath = Vector2.left;
        _pacMan = GameObject.Find("Pacman");
        _pacManMovement = _pacMan.GetComponent<PacmanMovement>();
    }

    private void Update()
    {
        if (!_coroutineRunning && _pacManMovement.tileData[(Vector2) transform.position + _currentPath])
        {
            StartCoroutine(Move(_currentPath));
        }

        if (!_coroutineRunning && !_pacManMovement.tileData[(Vector2) transform.position + _currentPath])
        {
            ChangePath();
        }

        if (Mathf.Abs(_pacMan.transform.position.x - transform.position.x) < 10 && Mathf.Abs(_pacMan.transform.position.y - transform.position.y) < 10)
        {
            FollowPacman();
        }
    }
    
    //Object Movement
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
            _currentSprite = blinkySprites[0];
        }
        if (_currentPath == Vector2.left)
        {
            _currentSprite = blinkySprites[3];
        }
        if (_currentPath == Vector2.up)
        {
            _currentSprite = blinkySprites[1];
        }
        if (_currentPath == Vector2.down)
        {
            _currentSprite = blinkySprites[2];
        }

        gameObject.GetComponent<SpriteRenderer>().sprite = _currentSprite;
    }

    //If clyde reaches a wall he will randomly turn towards other available routes
    private void ChangePath()
    {
        if (_pacManMovement.tileData[(Vector2) transform.position + Vector2.right])
        {
            _availableDirections.Add(Vector2.right);
        }
        if (_pacManMovement.tileData[(Vector2) transform.position + Vector2.left])
        {
            _availableDirections.Add(Vector2.left);
        }
        if (_pacManMovement.tileData[(Vector2) transform.position + Vector2.up])
        {
            _availableDirections.Add(Vector2.up);
        }
        if (_pacManMovement.tileData[(Vector2) transform.position + Vector2.down])
        {
            _availableDirections.Add(Vector2.down);
        }
        
        var rnd = new System.Random();
        var index = rnd.Next(_availableDirections.Count);

        _currentPath = _availableDirections[index];
        
        _availableDirections.Clear();
    }

    private void FollowPacman()
    {
        
    }
}
