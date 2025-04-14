using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompEnemy : MonoBehaviour
{
    public string targetTag = "BasicEnemy";
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BasicEnemy")) 
        {
            Destroy(collision.gameObject);
        
        }
    }

}


  
