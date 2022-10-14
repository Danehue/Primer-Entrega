using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetcsMecanics : MonoBehaviour
{
    public Transform setPoint;  
    public GameObject player;  

    // Start is called before the first frame update
    void Start()
    {
        // setPoint = new Vector3(2,2,2);
        Debug.Log(setPoint.position);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void grabObject()
    {
        float dist = Vector3.Distance(transform.position, player.transform.position);
        if(dist < 5)
        {
            transform.position = setPoint.position;
        }
    }
}
