using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLowerBounds : MonoBehaviour
{
    private int width = 20;

    void Start()
    {
        LowerBound();        
    }

    //Creates the bottom wall so player can get out. This is independent of the grid generator because it's easier this way 
    private void LowerBound()
    {
        GameObject lowerBound = (GameObject) Instantiate(Resources.Load("BlackBG"));

        int x = -10;
        
        for (int i = 0; i < width; i++)
        {
            GameObject tile = Instantiate(lowerBound, transform);
    
            tile.transform.position = new Vector2(x,-1);
            x++;
        }
        Destroy(lowerBound);
    }
}
