using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompEnemy : MonoBehaviour
{
    //Donovan and ben
    //4/19/2025
    // handles destroying enemies after they have been jumped on
    public string targetTag = "BasicEnemy";
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BasicEnemy")) 
        {
            Destroy(collision.gameObject);
        
        }
    }

}


  
