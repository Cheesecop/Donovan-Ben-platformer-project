using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinEnemy : MonoBehaviour
{
    //Donovan and ben
    //4/19/2025
    // allows the player's spin attack to destroy enemies and crates
    public CharController charController;
    // Start is called before the first frame update
    
    private void OnCollisionEnter(Collision collision)
    {
        if(charController.attacking == true) 
        {
            Destroy(gameObject);
        
        }
        else
        {
            charController.lives--;
            charController.Respawn();
        }
    }
}
