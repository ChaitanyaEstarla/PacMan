using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Pinky : MonoBehaviour
{
    public List<Sprite> pinkySprites;
    
    private bool _isMoving, _isLookingAround;
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
        _isMoving = false;
        _isLookingAround = false;
    }
    private void Update()
    {
        if (!_isMoving && !_isLookingAround)
        {
            StartCoroutine(LookAround());
        }

        if (_pacMan.transform.position.x == gameObject.transform.position.x && !_isMoving)
        {
            if (_pacMan.transform.position.y < gameObject.transform.position.y)
            {
                _currentPath = Vector2.down;
                StartCoroutine(Move(_currentPath));
            }
            if (_pacMan.transform.position.y > gameObject.transform.position.y)
            {
                _currentPath = Vector2.up;
                StartCoroutine(Move(_currentPath));
            }
        }
        
        if (_pacMan.transform.position.y == gameObject.transform.position.y && !_isMoving)
        {
            if (_pacMan.transform.position.x < gameObject.transform.position.x)
            {
                _currentPath = Vector2.left;
                StartCoroutine(Move(_currentPath));
            }
            if (_pacMan.transform.position.x > gameObject.transform.position.x)
            {
                _currentPath = Vector2.right;
                StartCoroutine(Move(_currentPath));
            }
        }
    }
    
    private IEnumerator Move(Vector2 direction)
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
