using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPieces : MonoBehaviour
{
    private Puzzlepiece Puzzlepiece;
    public Puzzlepiece pieceInUse=null;

    void Start()
    {
        Puzzlepiece = GetComponentInChildren<Puzzlepiece>();
    }

 
    void Update()
    {

    }
}
