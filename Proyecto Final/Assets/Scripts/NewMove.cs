using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMove : MonoBehaviour
{
    // MyControls[] controls;
    Rigidbody rb;

    public Camera FPSCamera;

    public float horizontalCam = 700f;
    public float verticalCam = 700f;
    public float velocity = 20f;
    // Start is called before the first frame update
    void Start()
    {
        // controls = new MyControls()[4];
        rb = GetComponent<Rigidbody>();
        // controls = new MyControls[4];
    }

    void Update() 
    {
        float h = horizontalCam * Input.GetAxis("Mouse X") * Time.deltaTime;
        float v = verticalCam * Input.GetAxis("Mouse Y") * Time.deltaTime;

        transform.Rotate(0,h,0);
        FPSCamera.transform.Rotate(-v,0,0);

        // controls[0].direction = transform.forward;
        // controls[1].direction = -transform.forward;
        // controls[2].direction = transform.right;
        // controls[3].direction = -transform.right;
        // if(Input.GetKeyDown(KeyCode.W)) controls[0].key = "up";
        // if(Input.GetKey(KeyCode.S)) controls[1].key = "down";
        // if(Input.GetKey(KeyCode.D)) controls[2].key = "right";
        // if(Input.GetKey(KeyCode.A)) controls[3].key = "left";
        
  
        // Vector3 movePlayer = transform.position;
        // for (int i = 0; i < controls.Length; i++)
        // {
        //     Debug.Log(i);
        //     if(Input.GetKey(controls[i].key))
        //     {
        //         Debug.Log("hola");
        //         movePlayer += controls[i].direction * velocity * Time.deltaTime;
        //     }
        // }
        // rb.MovePosition(movePlayer);
    }

    void FixedUpdate()
    {
        Vector3 movePlayer = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        rb.MovePosition(rb.position + movePlayer * Time.deltaTime * velocity);
    }
    
    // public class MyControls
    // {
    //     public Vector3 direction;
    //     public string key;
    // }
}
