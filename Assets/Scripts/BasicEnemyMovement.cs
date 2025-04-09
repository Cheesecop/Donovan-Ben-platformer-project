using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BasicEnemyMovement : MonoBehaviour
{
    public float speed = 10;
    private new Rigidbody rigidbody;
    public Vector3 direction;
    
    // Start is called before the first frame update
    void Start()
    {
       

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MoveEnemy()
    {
        transform.position += direction * speed * Time.deltaTime;

       

    }
}
