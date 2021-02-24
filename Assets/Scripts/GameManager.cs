using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int defaultRoadLength;

    public int startPoint;
    public int endPoint = 10;

    public GridManager grid;

    void Start()
    {
        defaultRoadLength = 5;
        for (int i = 0; i < defaultRoadLength; i++)
        {
            grid.CreateLevel(startPoint, endPoint);
            startPoint += 10;
            endPoint += 10;
        }
    }
}
