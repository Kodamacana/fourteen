using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementN : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool space = false;
    bool crouch = false;
    public bool isSpecialPower = false;
   
    void Update()
    {
        if (!Input.GetKey(KeyCode.Space))
        {
            horizontalMove = Input.GetAxisRaw("HorizontalN") * runSpeed;
        }

        if (Input.GetButtonDown("JumpN"))
        {
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            space = !space;
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
        if (Input.GetKey(KeyCode.Space) && space)
        {
            horizontalMove = Input.GetAxisRaw("HorizontalN") * runSpeed * (Mathf.Abs(transform.GetComponent<CharacterController2D>().m_Rigidbody2D.velocity.y* 0.3f) +1f);
        }

        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, isSpecialPower, space);
        jump = false;
    }
}
