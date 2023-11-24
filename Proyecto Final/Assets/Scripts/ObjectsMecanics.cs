using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsMecanics : MonoBehaviour
{
    public Transform setPoint;  
    public GameObject player;  
    public GameObject cameraParent;  
    public Camera cam;

    private GameObject cube;
    private float range;
    private bool grabbingObject;
    private bool setPositionOnce;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        range = 9f;
        grabbingObject = false;
        setPositionOnce = true;
    }

    // Update is called once per frame
    void Update()
    {
        chackDistance();
        grabObject();
    }

    // void chackDistance()
    // {
    //     float dist = Vector3.Distance(transform.position, player.transform.position);
    //     if(dist < 8.5f)
    //     {
    //         // player.transform.GetComponent<Player>().grabObject();
            
    //     }
    // }

    void chackDistance()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            if(hit.transform.gameObject.tag == "Object")
            {
                if(Input.GetKey(KeyCode.E))
                {
                    cube = hit.transform.gameObject;
                    grabbingObject = true;
                }
            }
        }
    }

    void grabObject()
    {
        if(grabbingObject)
        {
            cube.transform.SetParent(cameraParent.transform);
            rb = cube.GetComponent<Rigidbody>();
            rb.freezeRotation = true;
            rb.constraints = RigidbodyConstraints.FreezePosition;
            player.transform.GetComponent<PlayerMovement>().grabObject();
            // if(setPositionOnce)
            {
                cube.transform.position = setPoint.position;
                setPositionOnce = false;
            }
        }
        if(Input.GetKeyUp(KeyCode.E))
        {
            cube.transform.parent = null;
            rb.freezeRotation = false;
            rb.constraints = RigidbodyConstraints.None;
            player.transform.GetComponent<PlayerMovement>().dropObject();
            grabbingObject = false;
            setPositionOnce = true;
        }
    }
}
