using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinEnemy : MonoBehaviour
{
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
