using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzlepiece : MonoBehaviour
{
    //Variables
    public float speed = 3;                     // constant speed
    private AllPieces AllPieces;                // access to other script
    private PlatformSquares PlatformSquares;    // access to other script
    private PuzzleSquare PuzzleSquare;          // access to other script
    GameObject player;                          // keeps track of player's postition to follow it
    bool trigger = false;                       // if collision triggered; variable can be deleted later
    public bool pieceMove = false;              // if piece needs to be moved
    public Vector3 originalPos;                 // the original position of each piece
    public bool stop = false;                   // if piece needs to be put down

    void Start()
    {
        AllPieces = GetComponentInParent<AllPieces>();
        PlatformSquares = GetComponent<PlatformSquares>();
        PuzzleSquare = GetComponent<PuzzleSquare>();
        originalPos = transform.position;
        player = GameObject.Find("PlayerHolder");
    }

    void Update()
    {
        checkShouldMove();
        checkStop();
        if (Input.GetKey(KeyCode.Space) && trigger == true && AllPieces.pieceInUse==null)
        {
            Debug.Log("move is true");
            pieceMove = true;
        }
        checkMove();
    }
    
    private void move()
    {
        Vector3 direction = new Vector3(player.transform.position.x + 2, player.transform.position.y, player.transform.position.z);
        transform.localPosition = direction;
    }

    void checkShouldMove() //to check if piece should move and tells to move
    {
        if ((pieceMove == true) && (AllPieces.pieceInUse == null))
        {
            Debug.Log("WRONG");
            AllPieces.pieceInUse = this;
        }
        if ((pieceMove == true) && (AllPieces.pieceInUse == this))
        {
            move();
            Debug.Log("This is piece in use: " + AllPieces.pieceInUse.name);
        }
    }

    void checkStop()    //to check if piece needs to be put down
    {
        if ((Input.GetKey(KeyCode.X))&& (AllPieces.pieceInUse==this))
        {
            stop = true;
            Debug.Log("should stop moving");
            AllPieces.pieceInUse=null;
            pieceMove = false;
        }
        else
        {
            stop = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collide with "+ this.gameObject.name);
        trigger = true;

    }

    private void OnTriggerExit(Collider other)
    {
        trigger = false;
    }

    void checkMove()
    { 
        int x; int z;
        if (stop==true)
        {
            
            if (this.transform.localPosition.x <= 3 && this.transform.localPosition.x >= 0 && this.transform.localPosition.y <= 3 && this.transform.localPosition.y >= 0)
            {
      
                Debug.Log("should snap?");
                x = Mathf.RoundToInt(this.transform.localPosition.x);
                z = Mathf.RoundToInt(this.transform.localPosition.z);

                if (PlatformSquares.grid[x,z]!=0)
                {
                    Debug.Log("WM=false");
                    Debug.Log("should not overlap");
                    transform.localPosition = originalPos;
                }
                else if (PlatformSquares.grid[x,z]==0)
                {
                    Debug.Log("WM=true");
                    Vector3 direction = new Vector3((float)x, 0, (float) z);
                    
                    transform.localPosition = direction;
                    Debug.Log("The number " + x + z + " is " + PlatformSquares.grid[x, z]);
                }

            }
        }
        
        
        
    }
}
