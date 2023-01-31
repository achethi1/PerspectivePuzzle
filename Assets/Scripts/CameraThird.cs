using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraThird : MonoBehaviour
{
    //Variables
    public bool firstPOV;
    private Camera Camera3POV;


    void Start()
    {
        Camera3POV = GetComponent<Camera>();
        /*
        if (firstPOV == false)
        {
            Camera3POV.enabled = true;
        }
        else
        {
            Camera3POV.enabled = false;
        }*/
    }

    private void Update()
    {
        if (firstPOV == false)
        {
            Camera3POV.enabled = true;
        }
        else
        {
            Camera3POV.enabled = false;
        }
    }
}
