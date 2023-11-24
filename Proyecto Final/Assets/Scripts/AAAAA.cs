using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AAAAA : MonoBehaviour
{

    private float mouseX = .0f;
    private float mouseY = .0f;
    private float minY = -17f;
    private Rigidbody rb;

    [SerializeField] float speed;
    [SerializeField] float sensitivity = 2f; 
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = gameObject.GetComponent<Rigidbody>();
        // Time.timeScale = .1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(rb.transform.position, Vector3.down,4f))
        {
            rb.velocity = new Vector3(rb.velocity.x, 10f,rb.velocity.z);
        }
        Look();
        if(rb.velocity.y <= minY)
        {
            rb.velocity = new Vector3(rb.velocity.x, minY, rb.velocity.z);
        }
    }

    void FixedUpdate()
    {
        Movement();   
    }

    void Look()
    {
        mouseY -= Input.GetAxisRaw("Mouse Y") * sensitivity;
        mouseY = Mathf.Clamp(mouseY, -90f,90f);
        mouseX += Input.GetAxisRaw("Mouse X") * sensitivity;
        Camera.main.transform.localRotation = Quaternion.Euler(mouseY, mouseX, 0);
    }

    void Movement()
    {
        Vector2 axis = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * speed;
        Vector3 forward = new Vector3(-Camera.main.transform.right.z,0f,Camera.main.transform.right.x);
        Vector3 moveDirection = (forward * axis.x + Camera.main.transform.right * axis.y + Vector3.up * rb.velocity.y);
        rb.AddForce(rb.position + moveDirection * Time.deltaTime);

        RaycastHit hit;
        if(Physics.Raycast(rb.transform.position, Vector3.down, out hit, 10f))
        {
            if(hit.transform.CompareTag("Ground"))
            {
                rb.velocity = moveDirection;
            }
        }
    }
}
