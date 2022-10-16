using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMousePress : MonoBehaviour
{

    public Animator anim;
    public Light light;
    public GameObject platform;

    public float timer;

    private Vector3 platformInitialPosition;
    private Vector3 platformActualPosition;
    private Vector3 platformMaxY;
    private bool movePlatform;

    // Start is called before the first frame update
    void Start()
    {
        light.color = Color.red;
        platformInitialPosition = platform.transform.position;
        platformMaxY = new Vector3(0,15,0);
        timer = 10;
        movePlatform = false;
    }

    // Update is called once per frame
    void Update()
    {
        platformActualPosition = platform.transform.position;
        handleTimer();
    }

    void OnMouseDown() 
    {
        movePlatform = true;
    }

    void handleTimer()
    {
        if(movePlatform == true)
        {
            anim.SetBool("buttonPressed",true);
            light.color = Color.green;
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                timer = 10;
                light.color = Color.red;
                anim.SetBool("buttonPressed",false);  
                movePlatform = false; 
            }
        }
    }
}
