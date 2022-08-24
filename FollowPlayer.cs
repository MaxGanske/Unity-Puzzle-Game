using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{

    NavMeshAgent nav;

    void Start()
    {

        nav = GetComponent<NavMeshAgent>();

    }


    void Update()
    {
        nav.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);

       
    }
    
}
