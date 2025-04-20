using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    //Donovan and ben
    //4/19/2025
    // takes away a life and respawns player on collision with any object that has the script
    public CharController charController;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<CharController>())
        {
            charController.lives--;
            charController.Respawn();
        }
    }
}
