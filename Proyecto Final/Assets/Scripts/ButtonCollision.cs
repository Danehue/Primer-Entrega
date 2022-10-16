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
    private Vector3 doorActualPosition;
    private Vector3 doorMaxY;
    // Start is called before the first frame update
    void Start()
    {
        doorInitialPosition = door.transform.position;
        doorMaxY = new Vector3(0,9,0);
    }

    // Update is called once per frame
    void Update()
    {
        doorActualPosition = door.transform.position;
    }

    void OnTriggerStay(Collider other)
    {
        Renderer buttonRend = GetComponent<Renderer>();
        Renderer cableRend = cable.GetComponent<Renderer>();

        buttonRend.material = green;
        cableRend.material = green;

        if(doorActualPosition.y <= doorInitialPosition.y + doorMaxY.y)
        {
            door.transform.position += Vector3.up;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Renderer buttonRend = GetComponent<Renderer>();
        Renderer cableRend = cable.GetComponent<Renderer>();
     
        buttonRend.material = red;
        cableRend.material = red;
        door.transform.position = doorInitialPosition;  
    }
}
