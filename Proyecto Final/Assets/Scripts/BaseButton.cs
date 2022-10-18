using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseButton : MonoBehaviour
{
    // public bool movePlatform;

    public GameObject button;
    public GameObject uiButton;
    // Start is called before the first frame update
    void Start()
    {
        // movePlatform = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if(other.transform.gameObject.tag == "Player")
        {
            // Debug.Log("Stay");
            uiButton.SetActive(true);
            if(Input.GetKey(KeyCode.E))
            {
                button.transform.GetComponent<ButtonMousePress>().keyPressed();
            }
        }
    }
    
    void OnTriggerExit(Collider other) 
    {
        uiButton.SetActive(false);
    }
}
