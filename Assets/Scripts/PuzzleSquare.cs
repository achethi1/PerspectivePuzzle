using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSquare : MonoBehaviour
{
    private Puzzlepiece Puzzlepiece;
    private PlatformSquares PlatformSquares;
    GameObject platSquare;
    public bool wrongMove = false;

    void Start()
    {
        Puzzlepiece = GetComponent<Puzzlepiece>();
        PlatformSquares = GetComponent<PlatformSquares>();
    }

   
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("collide SQUARE");
        if (other.gameObject.name.Contains("platsquares"))
        {
            platSquare = other.gameObject;
            if (Puzzlepiece.stop == true)
            {
                changeGrid(1,Mathf.RoundToInt(platSquare.transform.localPosition.x), Mathf.RoundToInt(platSquare.transform.localPosition.z));
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("platsquares"))
        {
            if (Puzzlepiece.pieceMove == true)
            {
                changeGrid(0, Mathf.RoundToInt(platSquare.transform.localPosition.x), Mathf.RoundToInt(platSquare.transform.localPosition.z));
            }
        }
    }

    private void changeGrid(int change,int x, int z)
    {
        if (x < 4 && z < 4)
        {
            if (PlatformSquares.grid[x, z] == change)
            {
                Debug.Log("doesnt change change");
                wrongMove = true;
            }
            else
            {
                PlatformSquares.grid[x, z] = change;
                wrongMove = false;
            }
        }
    }
}
