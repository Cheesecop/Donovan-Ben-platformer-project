using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePlat : MonoBehaviour
{
    public int breakTimer = 5;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<CharController>())
        {
            StartCoroutine(BreakTimer());
            StartCoroutine(ReturnTimer());

        }
    }

    private IEnumerator BreakTimer()
    {
        yield return new WaitForSeconds(breakTimer);
        gameObject.SetActive(false);
    }
    private IEnumerator ReturnTimer()
    {
        yield return new WaitForSeconds(breakTimer);
        gameObject.SetActive(true);
    }
}
