using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WumpaFruit : MonoBehaviour
{
    //Donovan and ben
    //4/19/2025
    // handles adding wumpa fruit to player inventory
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
