using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenStonePickUp : MonoBehaviour
{

    public int valueGreenStone;

    public GameObject pickupEffect;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Player")
        {


            Instantiate(pickupEffect, transform.position, transform.rotation);
            FindObjectOfType<PrefabSpawner>().increaseAmafo(1);
            FindObjectOfType<SoundManager>().PlaySound("greenstone");


            Destroy(gameObject);
        }

    }
}
