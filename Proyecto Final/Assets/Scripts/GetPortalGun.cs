using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPortalGun : MonoBehaviour
{

    public GameObject portalGunInPlayer;
    public GameObject portalGunInMap;
    public GameObject player;

    public GameObject blue;
    public GameObject orange;
    public GameObject none;
    public GameObject both;
    public GameObject crosshair;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        portalGunInPlayer.SetActive(true);
        portalGunInMap.SetActive(false);
        player.SetActive(false);
        none.SetActive(true);
        crosshair.SetActive(false);
        Debug.Log("Fin!");
    }
}
