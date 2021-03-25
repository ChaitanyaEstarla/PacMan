using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private const int EnemyNumbers = 4;
    private List<GameObject> _enemies = new List<GameObject>();
    private GameObject[] _enemyResource;
    
    private void Start()
    {
        _enemyResource = new GameObject[EnemyNumbers];
        
        var inky    = (GameObject) Instantiate(Resources.Load("Inky"));
        _enemyResource[0] = inky;
        var blinky  = (GameObject) Instantiate(Resources.Load("Blinky"));
        _enemyResource[1] = blinky;
        var pinky   = (GameObject) Instantiate(Resources.Load("Pinky"));
        _enemyResource[2] = pinky;
        var clyde   = (GameObject) Instantiate(Resources.Load("Clyde"));
        _enemyResource[3] = clyde;

        foreach (var enemy in _enemyResource)
        {
            for (var i = 0; i < 5; i++)
            {
                InstantiateEnemies(enemy);
            }
        }
        
        foreach (var enemy in _enemyResource)
        {
            Destroy(enemy);
        }
        Debug.Log(_enemies.Count);
    }

    private void Update()
    {
        
    }
    
    private void InstantiateEnemies(GameObject enemyResource)
    {
        var enemy = Instantiate(enemyResource, transform);
        
        _enemies.Add(enemy);
        enemy.SetActive(false);
    }
}
