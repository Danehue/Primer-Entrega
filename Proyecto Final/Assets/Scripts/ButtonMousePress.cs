using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMousePress : MonoBehaviour
{
    public Light light;
    // Start is called before the first frame update
    void Start()
    {
        light.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() 
    {
        light.color = Color.green;
    }
}
