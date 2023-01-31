using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFirst : MonoBehaviour
{
    //Variables
    public bool firstPOV;
    private Camera Camera1POV;
    public float tiltAngle;
    private Quaternion initialRotation;
    public float _cameraRotationSpeed = 0.1f;


    void Start()
    {
        Camera1POV = GetComponent<Camera>();
        initialRotation = transform.rotation;
        /*
         if (firstPOV==true)
         {
             Camera1POV.enabled = true;
         }
         else
         {
             Camera1POV.enabled = false;
         }*/

    }

    private void Update()
    {
        Camera1POV = GetComponent<Camera>();

        if (firstPOV == true)
        {
            Camera1POV.enabled = true;
        }
        else
        {
            Camera1POV.enabled = false;
        }
        if (Input.GetKey("a"))
        {
            tilt(true); 
        }
        else if (Input.GetKey("z"))
        {
            tilt(false); 
        }
      
    }

    private void tilt(bool tilt)
    {
        float angle = transform.eulerAngles.z;
        if (tilt)
        {
            angle += _cameraRotationSpeed;
        }
        else
        {
            angle -= _cameraRotationSpeed;
        }
        angle = Mathf.Clamp(angle, 0, 90);
        transform.eulerAngles = new Vector3(0, angle, 0);
        /*angle = angle + initialRotation.eulerAngles.x;
        Quaternion newRotation = Quaternion.AngleAxis(angle, Vector3.left);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, .5f);
        tiltAngle = angle;*/
    }


}
