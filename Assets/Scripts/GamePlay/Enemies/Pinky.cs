using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Pinky : MonoBehaviour
{
    public List<Sprite> pinkySprites;
    
    private bool _isMoving, _isLookingAround, _coroutineRunning;
    private float _randomSeconds;
    
    private const float TimeToMove = 0.18f;
    
    private Sprite _currentSprite;
    private PacmanMovement _pacManMovement;
    private GameObject _pacMan;
    
    private Vector2 _currentPos, _nextPos;
    private Vector2 _currentPath;

    private void Start()
    {
        _pacMan = GameObject.Find("Pacman");
        _pacManMovement = _pacMan.GetComponent<PacmanMovement>();
        _isLookingAround = false;
    }
    private void Update()
    {
        if (!_isMoving && !_isLookingAround)
        {
            StartCoroutine(LookAround());
        }

        if (_pacMan.transform.position.x == transform.position.x && !_isMoving)
        {
            _currentPath = _pacMan.transform.position.y > transform.position.y ? Vector2.up : Vector2.down;
            _isMoving = true;
        }
        else if (_pacMan.transform.position.y == transform.position.y && !_isMoving)
        {
            _currentPath = _pacMan.transform.position.x > transform.position.x ? Vector2.right : Vector2.left;
            _isMoving = true;
        }
        
        if (_isMoving && !_coroutineRunning)
        {
            if(_pacManMovement.tileData[(Vector2) transform.position + _currentPath])  StartCoroutine(Move(_currentPath));
            if (!_pacManMovement.tileData[(Vector2) transform.position + _currentPath])
            {
                _isMoving = false;
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

    //While in the idle state Pinky will look around in all directions
    private IEnumerator LookAround()
    {
        _isLookingAround = true;
        foreach (var sprite in pinkySprites)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
            _randomSeconds = Random.Range(1.5f, 2.5f);
            yield return new WaitForSeconds(_randomSeconds);
        }
        _isLookingAround = false;
    }
    
    //Sprite will change according to the direction Blinky is moving in
    private void ChangeSprite()
    {
        if (_currentPath == (Vector2.right))
        {
            _currentSprite = pinkySprites[0];
        }
        if (_currentPath == Vector2.left)
        {
            _currentSprite = pinkySprites[3];
        }
        if (_currentPath == Vector2.up)
        {
            _currentSprite = pinkySprites[1];
        }
        if (_currentPath == Vector2.down)
        {
            _currentSprite = pinkySprites[2];
        }

        gameObject.GetComponent<SpriteRenderer>().sprite = _currentSprite;
    }
}
