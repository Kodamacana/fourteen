using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementN : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

   
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("HorizontalN") * runSpeed;

        if (Input.GetButtonDown("JumpN"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("CrouchN"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("CrouchN"))
        {
            crouch = false;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
