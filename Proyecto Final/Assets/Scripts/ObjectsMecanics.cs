using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsMecanics : MonoBehaviour
{
    public Transform setPoint;  
    public GameObject player;  

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        chackDistance();
    }

    void chackDistance()
    {
        float dist = Vector3.Distance(transform.position, player.transform.position);
        if(dist < 8.5f)
        {
            // player.transform.GetComponent<Player>().grabObject();
            grabObject();
        }
    }

    void grabObject()
    {
        if(Input.GetKey(KeyCode.E))
        {
            transform.position = setPoint.position;
            player.transform.GetComponent<PlayerMovement>().grabObject();
        }
        else
        {
            player.transform.GetComponent<PlayerMovement>().dropObject();
        }
    }
}
