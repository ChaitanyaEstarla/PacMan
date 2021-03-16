using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Inky : MonoBehaviour
{
    private int _direction;
    private bool _directionToChoose;
    private PacmanMovement _pacManMovement;
    private GameObject _pacMan;
    private bool _isMoving = false;
    private const float TimeToMove = 0.5f;
    private Vector2 _currentPos, _nextPos;
    private Vector2 _checkSide;

    private void OnEnable()
    {
        _directionToChoose = Random.value> 0.5f;
        _direction = _directionToChoose ? 1:-1;
    }

    private void Start()
    {
        _pacMan = GameObject.Find("Pacman");
        _pacManMovement = _pacMan.GetComponent<PacmanMovement>();
    }

    private void Update()
    {
        if (!_isMoving && _pacManMovement.tileData[(Vector2) transform.position + (Vector2.right * _direction)])
        { 
            _checkSide =  Vector2.up * _direction;
            StartCoroutine(MovePlayerTest(Vector2.right *_direction, 0));
        }

        /*if (!_isMoving && _pacManMovement.tileData[(Vector2)transform.position + _checkSide])
        {
            StartCoroutine(MovePlayerTest(_checkSide*_direction, 0));
        }*/
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
