using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLevel : MonoBehaviour
{
    private int _startPoint;
    private int _endPoint = 10;
    
    public GridManager grid;
    
    void Start()
    {
        //Initial gird generated at the beginning of the game
        grid.CreateLevel(_startPoint, _endPoint);
    }
}
