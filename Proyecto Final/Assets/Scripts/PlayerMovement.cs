using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;

    bool isWalking;
    bool isJumping;
    bool cantJump = false;

    public Camera firstPerson;
    public Camera thirdPerson;


    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jump = 3f;

    public Transform groundCheck;
    public float groundDistance = .4f;
    public LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        firstPerson.enabled = true;
        thirdPerson.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jump * -2f * gravity);

            anim.SetBool("isJumping",true);
            anim.SetBool("isWalking",false);
        }
        else if(!isGrounded)
        {
            anim.SetBool("isJumping",false);
        }
        
        if(x != 0 || z != 0 && isGrounded)
        {
            anim.SetBool("isWalking",true);
        }
        else
        {
            anim.SetBool("isWalking",false);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void grabObject()
    {
        cantJump = true;
        anim.SetBool("isGrabing",true);
    }

    public void dropObject()
    {
        cantJump = false;
        anim.SetBool("isGrabing",false);
    }

    void changeCamera()
    {
        if(Input.GetKey(KeyCode.P))
        {
            if(firstPerson.enabled)
            {
                firstPerson.enabled = true;
                thirdPerson.enabled = false;
            }
            else
            {
                firstPerson.enabled = false;
                thirdPerson.enabled = true;
            }
        }
    }
}
