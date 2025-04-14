using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WumpaFruit : MonoBehaviour
{
    public CharController charController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharController>())
        {
            charController.fruitCount++;
            Destroy(gameObject);
        }
    }

}
