using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMecanics : MonoBehaviour
{
    public Camera cam;
    public GameObject portalBlue;
    public GameObject portalOrange;

    private float range = Mathf.Infinity;
    private int LayerPortal;
    // Start is called before the first frame update
    void Start()
    {
        LayerPortal = LayerMask.NameToLayer("NotAPortalPlace");
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
    }

    void shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            if(hit.transform.gameObject.layer != LayerPortal)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    // if(hit.transform.gameObject.tag == "Portal")
                    {
                        portalBlue.transform.position = hit.point;
                        portalBlue.transform.rotation = Quaternion.LookRotation(hit.normal);
                        // Instantiate(portalBlue,hit.point,Quaternion.LookRotation(hit.normal));
                    }
                }
                if(Input.GetMouseButtonDown(1))
                {
                    // if(hit.transform.gameObject.tag == "Portal")
                    {
                        portalOrange.transform.position = hit.point;
                        portalOrange.transform.rotation = Quaternion.LookRotation(hit.normal);
                        // Instantiate(portalOrange,hit.point,Quaternion.LookRotation(hit.normal));
                    }
                }
            }
            
        }
    }

    private void OnCollisionEnter(Collision other) {
        
    }
}
