using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;


public class CharController : MonoBehaviour
{

    //A boolean value that will tell you if you are within .1 Unity Unit from the ground
    private bool grounded;
    //The rigid body attached to the player
    private new Rigidbody rigidbody;
    //how close are we to a wall on our left side
    private float distance_to_wall_left = 2f;
    //how close are we to a wall on our right side
    private float distance_to_wall_right = 2f;
    //how close are we to a wall going forward
    private float distance_to_wall_forward = 2f;
    //how close are we to a wall going backwards
    private float distance_to_wall_back = 2f;
    //a position for the spawn point
    private Vector3 spawnPoint;

    //the float that affects speeed
    public float speed = 10;
    //the players lives
    public int lives = 3;
    //the multiplier for jumping
    public float jumpForce = 8f;

    //the number of fruit the player has
    public int fruitCount = 0;
    //the threshold for how many fruit you need for an extra life
    public int fruitThresh = 20;



    //Start is a function that is called once when the object is Instatiated. 
    void Start()
    {
        //make the rigidbody for the player on start
        rigidbody = GetComponent<Rigidbody>();
        //Create the spawn point when the game starts
        spawnPoint = transform.position;

    }

    // Update is a function that is called once per frame
    void Update()
    {
        //checking each framme for if the player jumps
        Jump();

        //if character goes below -100y respawn
        if (gameObject.transform.position.y <= -100)
        {
            lives--;
            Respawn();
        }

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        //if you collect enough fruit, the lives go up
        if (fruitCount >= fruitThresh)
        {
            fruitCount -= fruitThresh;
            lives++;
        }

    }

    private void FixedUpdate()
    {
        PlayerMovement();
        DistanceToWall();
        Vector3 oldRot = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0, oldRot.y, 0);
        SpinAttack();
    }

    private void PlayerMovement()
    {

        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float straffe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        if (!grounded)
            straffe /= 2;

        if (!grounded)
            translation /= 2;


        //if I'm too close to a wall, don't go that direction anymore
        if ((distance_to_wall_back <= .6 && translation < 0) || (distance_to_wall_forward <= .6 && translation > 0))
        {
            translation = 0;
        }
        if ((distance_to_wall_right < .6 && straffe > 0) || (distance_to_wall_left < .6 && straffe < 0))
        {
            straffe = 0;
        }

        //Translate to move.
        transform.Translate(straffe, 0, translation);


    }


    private void Jump()
    {
        //if player presses space while grounded
        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }



    private void DistanceToWall()
    {
        RaycastHit hit;
        Ray left_ray = new Ray(transform.position, -transform.right);
        Ray front_ray = new Ray(transform.position, transform.forward);
        Ray back_ray = new Ray(transform.position, -transform.forward);
        Ray right_ray = new Ray(transform.position, transform.right);

        //Raycast left to see if I find a wall
        if (Physics.Raycast(left_ray, out hit) && !hit.collider.isTrigger)
        {
            distance_to_wall_left = hit.distance;
        }
        else
        {
            distance_to_wall_left = 3;
        }

        //Raycast center forward to find a wall
        if (Physics.Raycast(front_ray, out hit) && !hit.collider.isTrigger)
        {
            distance_to_wall_forward = hit.distance;
        }
        else
        {
            distance_to_wall_forward = 3;
        }

        //Raycast center forward to find a wall
        if (Physics.Raycast(back_ray, out hit) && !hit.collider.isTrigger)
        {
            distance_to_wall_back = hit.distance;
        }
        else
        {
            distance_to_wall_back = 3;
        }

        //Raycast right to find a wall
        if (Physics.Raycast(right_ray, out hit) && !hit.collider.isTrigger)
        {
            distance_to_wall_right = hit.distance;
        }
        else
        {
            distance_to_wall_right = 3;
        }


        //Raycast down to find the ground
        if (Physics.Raycast(transform.position, -transform.up, 1.1f))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }


    }

    public Material spin;
    public Material orange;
    public bool attacking = false;

    //if the player presses E, do the spin attack
    private void SpinAttack()
    {
        if (Input.GetKey(KeyCode.E))
        {
            attacking = true;
            gameObject.GetComponent<MeshRenderer>().material = spin;

            StartCoroutine(SpinWait());

        }
    }
    private IEnumerator SpinWait()
    {
        yield return new WaitForSeconds(1f);
        attacking = false;
        gameObject.GetComponent<MeshRenderer>().material = orange;
    }

    public void Respawn()
    {
        transform.position = spawnPoint;
        rigidbody.velocity = Vector3.zero;
    }
}
