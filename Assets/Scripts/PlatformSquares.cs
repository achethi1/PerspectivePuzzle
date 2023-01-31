using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSquares : MonoBehaviour
{
    //Variables
    public float numSquaresFilled;
    public static int[,] grid = new int[4,4];

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                grid[i, j] = 0;
                Debug.Log("The number " + i + j + " is " + grid[i, j]);
            }
        }
    }
    
    void Update()
    {
        if (checkFilled() == true)
        {
            Debug.Log("Game finished YAY");
        }
    }

    public bool checkFilled()
    {
        numSquaresFilled = 0;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (grid[i, j] == 1)
                {
                    numSquaresFilled++;
                }
            }
        }
        if (numSquaresFilled == 16)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
}
