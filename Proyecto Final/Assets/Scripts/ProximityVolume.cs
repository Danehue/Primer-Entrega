using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityVolume : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject radio;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, radio.transform.position);
        audioSource.volume = -dist/30 + 1;
    }
}
