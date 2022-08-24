using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{

    public int damageToGive = 1;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Vector3 hitDirection = other.transform.position - transform.position;
            hitDirection = hitDirection.normalized;
            FindObjectOfType<SoundManager>().PlaySound("damage");

            FindObjectOfType<HealthManager>().HurtPlayer(damageToGive, hitDirection);

        }
    }
}
