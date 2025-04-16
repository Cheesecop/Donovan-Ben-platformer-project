using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    public GameObject crateTop;
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<CharController>() && (gameObject.GetComponent<CharController>().attacking = true))
        {
            
        }
    }

}
