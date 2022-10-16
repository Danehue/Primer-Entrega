using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMousePress : MonoBehaviour
{
    public Light light;
    public GameObject platform;

    private Vector3 platformInitialPosition;
    private Vector3 platformActualPosition;
    private Vector3 platformMaxY;

    // Start is called before the first frame update
    void Start()
    {
        light.color = Color.red;
        platformInitialPosition = platform.transform.position;
        platformMaxY = new Vector3(0,15,0);
    }

    // Update is called once per frame
    void Update()
    {
        platformActualPosition = platform.transform.position;
    }

    void OnMouseDown() 
    {
        light.color = Color.green;
        movePlatform();
    }

    void movePlatform()
    {
        // if(platformActualPosition.y < platformInitialPosition.y + platformMaxY.y)
        // {
        // }
        // Debug.Log(platformActualPosition);
        // for (float i = platformInitialPosition.y + platformMaxY.y; i > platformActualPosition.y ; )
        // {
        //     platform.transform.position += Vector3.up;
        // }
    }
}
