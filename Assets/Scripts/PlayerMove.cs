using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float jumpForce = 8f;
    private new Rigidbody rigidbody;
    public float speed;
    public int lives;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
        SpinAttack();

    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && OnGround())
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }


    private bool OnGround()
    {
        bool onGround = false;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.2f))
        {
            onGround = true;
        }

        return onGround;


    }


    private void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //transform.position += Vector3.right * speed * Time.deltaTime;
            rigidbody.MovePosition(transform.position + (Vector3.right * speed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //transform.position += Vector3.left * speed * Time.deltaTime;
            rigidbody.MovePosition(transform.position + (Vector3.left * speed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            //transform.position += Vector3.left * speed * Time.deltaTime;
            rigidbody.MovePosition(transform.position + (Vector3.forward * speed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            //transform.position += Vector3.left * speed * Time.deltaTime;
            rigidbody.MovePosition(transform.position + (Vector3.back * speed * Time.deltaTime));
        }

    }

    public Material spin;
    public Material orange;
    public bool attacking = false;
    

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
        yield return new WaitForSeconds (1f);
        attacking = false;
        gameObject.GetComponent<MeshRenderer>().material = orange;

    }
}
