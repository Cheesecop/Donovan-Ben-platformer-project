using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    //Donovan and ben
    //4/19/2025
    // destroys the object and spawns fruit if stomped on or spin attacked
    public GameObject crateTop;
    public CharController charCtrl;
    public GameObject wumpaFruit;

    public int fruitCount;

    private void OnCollisionEnter(Collision collision)
    {
        if (charCtrl.attacking == true)
        {
            //remove the crate
            gameObject.SetActive(false);

            //spawn the wumpa fruits
            for (int i = fruitCount; i > 0; i--)
            {
                Instantiate(wumpaFruit, transform.position, transform.rotation);    

            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //remove the crate
        gameObject.SetActive(false);

        //spawn the wumpa fruits
        for (int i = fruitCount; i > 0; i--)
        {
            Instantiate(wumpaFruit, transform.position, transform.rotation);

        }

    }
}
