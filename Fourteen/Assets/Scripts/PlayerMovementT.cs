using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementT : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

   
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("HorizontalT") * runSpeed;

        if (Input.GetButtonDown("JumpT"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("CrouchT"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("CrouchT"))
        {
            crouch = false;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, false, false);
        jump = false;
    }
}
