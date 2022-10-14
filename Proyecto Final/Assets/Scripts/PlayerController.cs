using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public CharacterController controller;
    public float speed;
    public float turnSmoothTime = .1f;
    public Transform cam;
    public float gravity = 9.8f;

    private float turnSmoothVelocity; 

    float movX;
    float movY;
    Vector3 movPlayer;
    bool isWalking;
    bool isJumping;
    
    void Start()
    {
        speed = 20;
    }

    void Update()
    {
        handleJump();
        handleRun();
        handleMove();
        setGravity();
    }

    void handleMove()
    {
        
        float playerYPosition = transform.position.y;
        float movX = Input.GetAxis("Horizontal");
        float movY = Input.GetAxis("Vertical");
        movPlayer = new Vector3(movX, 0, movY).normalized;

        if(movPlayer.magnitude >= .1f)
        {
            float targetAngle = Mathf.Atan2(movPlayer.x, movPlayer.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            anim.SetBool("isWalking",true);
        }
        else
        {
            anim.SetBool("isWalking",false);
        }
    }

    void handleJump()
    {
        // Vector3 playerJump = new Vector3(0, 800, 0);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("isJumping",true);
            // rb.AddForce(playerJump);
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            anim.SetBool("isJumping",false);
        }
    }

    void handleRun()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = 40;
        }
        else
        {
            speed = 20;
        }
    }

    void setGravity()
    {
        
    }
}
