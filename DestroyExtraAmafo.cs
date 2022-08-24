using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExtraAmafo : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Destroy(this.gameObject);
        }
    }
}
