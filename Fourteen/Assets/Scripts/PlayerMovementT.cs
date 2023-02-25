using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementT : MonoBehaviour
{
    public CharacterController2D controller;
    [SerializeField] Animator T_Animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool space = false;
    bool crouch = false;


    void specialPower()
    {
        if (space)
        {
            transform.GetComponent<CharacterController2D>().m_JumpForce *= 2;
        }
        else
        {
            transform.GetComponent<CharacterController2D>().m_JumpForce /= 2;
        }
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("HorizontalT") * runSpeed;
        if (space)
        {
            horizontalMove = Input.GetAxisRaw("HorizontalT") * runSpeed * 2;
        }

        if (Input.GetButtonDown("JumpT"))
        {
            jump = true;
            T_Animator.SetBool("Run", false);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            space = !space;
            specialPower();
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
        if (Input.GetAxisRaw("HorizontalT") == 0)
        {
            T_Animator.SetBool("Run", false);
            T_Animator.SetBool("SRun", false);
        }
        else if(space)
        {
            T_Animator.SetBool("SRun", true);
        }
        else
        {
            T_Animator.SetBool("Run", true);
        }

        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, false, false);
        jump = false;
    }
}
