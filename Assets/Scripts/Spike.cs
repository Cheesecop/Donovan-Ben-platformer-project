using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public CharController charController;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<CharController>())
        {
            charController.lives--;
        }
    }
}
