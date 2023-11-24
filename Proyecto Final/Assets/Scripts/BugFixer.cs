using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugFixer : MonoBehaviour
{
    public GameObject player;
    CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = player.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Ground" || other.gameObject.tag == "Portal" || other.gameObject.tag == "Untagged")
        {
            player.GetComponent<AAAAA>().enabled = true;  
            // controller.enabled = true;
        }   
    }
}
