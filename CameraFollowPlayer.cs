using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{

    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offSet;

    
    void Start()
    {
        
    }

    
    void LateUpdate()
    {
        
        transform.position = target.position + offSet;

    }
}
