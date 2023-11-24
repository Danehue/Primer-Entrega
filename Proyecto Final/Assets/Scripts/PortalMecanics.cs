using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalMecanics : MonoBehaviour
{
    public Transform otherPortal;
    public GameObject player;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            Collider playerCollider = other.gameObject.GetComponent<Collider>();
            playerCollider.isTrigger = true;  
            // controller.enabled = false;
            // player.GetComponent<AAAAA>().enabled = false;  
        }  

        if(other.tag == "Object")
        {
            MeshCollider objectMeshCollider = other.gameObject.GetComponent<MeshCollider>();
            objectMeshCollider.isTrigger = true;
            Collider objectCollider = other.gameObject.GetComponent<Collider>();
            objectCollider.isTrigger = true; 
        } 
    }

    void OnTriggerExit(Collider other) 
    {
        if(other.tag == "Player")
        {
            Collider playerCollider = other.gameObject.GetComponent<Collider>();
            playerCollider.isTrigger = false;  
            // controller.enabled = true;
            // player.GetComponent<PlayerMovement>().enabled = true;  
        } 

        if(other.tag == "Object")
        {
            MeshCollider objectMeshCollider = other.gameObject.GetComponent<MeshCollider>();
            objectMeshCollider.isTrigger = false;
            Collider objectCollider = other.gameObject.GetComponent<Collider>();
            objectCollider.isTrigger = false;    
        } 
    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            // Rigidbody rb = other.GetComponent<Rigidbody>();
            
            Vector3 playerInverse = transform.InverseTransformPoint(other.transform.position);

            if(playerInverse.z <= .02)
            {
                other.transform.position = otherPortal.position + new Vector3(-playerInverse.x, +playerInverse.y, -playerInverse.z);

                Quaternion QInverse = Quaternion.Inverse(transform.rotation) * other.transform.rotation;
                other.transform.eulerAngles = Vector3.up * (otherPortal.eulerAngles.y - (transform.eulerAngles.y - other.transform.eulerAngles.y) + 180);
                Vector3 cam = Camera.main.transform.localEulerAngles;
                Camera.main.transform.localEulerAngles = Vector3.right * (otherPortal.eulerAngles.x + Camera.main.transform.localEulerAngles.x);

                Vector3 playerVelocity = transform.InverseTransformPoint(rb.velocity);
                rb.velocity =  -otherPortal.transform.forward * rb.velocity.y * 2;
            }
        }

        if(other.tag == "Object")
        {
            Rigidbody rbObject = other.gameObject.GetComponent<Rigidbody>();

            Vector3 objectInverse = transform.InverseTransformPoint(other.transform.position);

            if(objectInverse.z <= .02)
            {
                other.transform.position = otherPortal.position + new Vector3(-objectInverse.x, +objectInverse.y, -objectInverse.z);

                Quaternion QInverse = Quaternion.Inverse(transform.rotation) * other.transform.rotation;
                other.transform.eulerAngles = Vector3.up * (otherPortal.eulerAngles.y - (transform.eulerAngles.y - other.transform.eulerAngles.y) + 180);
                Vector3 cam = Camera.main.transform.localEulerAngles;
                Camera.main.transform.localEulerAngles = Vector3.right * (otherPortal.eulerAngles.x + Camera.main.transform.localEulerAngles.x);

                Vector3 objectVelocity = transform.InverseTransformPoint(rbObject.velocity);
                rbObject.velocity =  -otherPortal.transform.forward * rbObject.velocity.y * 2;
            }
        }
        
    }
}
