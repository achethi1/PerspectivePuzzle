using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variables
    public CharacterController ctrl;
    public float speed = 1;

    void Update()
    {
        move();
    }

    private void move()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 Move = transform.forward * vertical + transform.right * horizontal;
        ctrl.Move(speed * Time.deltaTime * Move);
    }

}
