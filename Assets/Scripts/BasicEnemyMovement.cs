using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BasicEnemyMovement : MonoBehaviour
{
    public float speed = 10;
    public Vector3 direction;
    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 direction = Vector3.right;
        transform.position += direction * speed * Time.deltaTime;

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Vector3 center = transform.position;
        

        if(!Physics.Raycast(center, Vector3.right, out hit, 1.62f))
        {
            Vector3 direction = Vector3.right;
            transform.position += direction * speed * Time.deltaTime;

        }
        if(!Physics.Raycast(center, Vector3.left, out hit, 1.62f))
        {
            Vector3 direction = Vector3.left ;
            transform.position += direction * speed * Time.deltaTime;

        }
    }

    private void MoveEnemy()
    {
        transform.position += direction * speed * Time.deltaTime;
        
            
       

    }

    
    
}
