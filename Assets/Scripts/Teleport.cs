using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform portalExit;


    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = portalExit.position;

        if (other.GetComponent<CharController>())
        {
            //set the respawn to the new portal exit when teleported
            other.GetComponent<CharController>().spawnPoint = transform.position;

        }

    }
}
