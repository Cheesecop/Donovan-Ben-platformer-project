using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BasicEnemyMovement : MonoBehaviour
{
    //Donovan and ben
    //4/19/2025
    //handles basic left and right forward and back movement
    
    public float speed = 10;
    public Vector3 direction;
    public float distance = 2.0f;
    public bool rotation;
    // Start is called before the first frame update
    void Start()
    {

       if (rotation == true) 
        {
            direction = Vector3.forward;
            
        }
       else 
        {
            direction = Vector3.left;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if (rotation == true)
        {

            MoveEnemy();
            TurnAroundLeft();
        }
        else if (rotation == false)
        {
            MoveEnemy();
            TurnAroundRight();

        }

    }

    private void MoveEnemy()
    {
        transform.position += direction * speed * Time.deltaTime;
        
            
       

    }
    private void TurnAroundLeft() 
    {
        if(OnGround() == false || WallForwardBack() == true)
        {
            direction = direction * -1;
        } 
    
    }
    private void TurnAroundRight() 
    {
        if(OnGround() == false || WallRightLeft() == true)
        {
            direction = direction * -1;
        } 
    
    }
    private bool OnGround() 
    {
        bool onGround = false;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 2.0f)) 
        {
            onGround = true;
        }
        return onGround;
    }
    private bool WallRightLeft() 
    {
        bool wall = false;

        RaycastHit hit;
        if(Physics.Raycast(transform.position,Vector3.left, out hit, distance)) 
        {
            wall = true;
        }
        else if(Physics.Raycast(transform.position, Vector3.right, out hit, distance)) 
        {
            wall = true;
        }
        return wall;
        
    }
    private bool WallForwardBack()
    {
        bool wall = false;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, distance))
        {
            wall = true;
        }
        else if (Physics.Raycast(transform.position, Vector3.back, out hit, distance))
        {
            wall = true;
        }
        return wall;

    }
}
