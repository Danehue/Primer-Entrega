using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCollision : MonoBehaviour
{
    public Material red;
    public Material green;
    public GameObject cable;
    public GameObject door;

    private Vector3 doorInitialPosition;
    // Start is called before the first frame update
    void Start()
    {
        doorInitialPosition = door.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerStay(Collider other)
    {
        Renderer buttonRend = GetComponent<Renderer>();
        Renderer cableRend = cable.GetComponent<Renderer>();
        if(other.transform.gameObject.tag == "Cube")
        {
            buttonRend.material = green;
            cableRend.material = green;
            door.transform.position = -doorInitialPosition;
        }
        else
        {
            buttonRend.material = red;
            cableRend.material = red;
            door.transform.position = doorInitialPosition;
        }
        
    }
}
