using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;

    bool isWalking;
    bool isJumping;

    public CharacterController controller;

    public float speed;
    public float gravity;
    public float jump;

    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        speed = 20f;
        gravity = -25.5f;
        jump = 6.5f;
        groundDistance = .4f;
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
        anim.SetBool("isGrabing",true);
    }

    public void dropObject()
    {
        anim.SetBool("isGrabing",false);
    }
}
