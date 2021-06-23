using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10;

    public LayerMask layerMask;
    public bool Grounded;
    private Rigidbody rb;

    public bool darkSide;
    public bool simulation;

    //public bool darkSide;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Input
        float x = Input.GetAxisRaw("Horizontal") * speed;
        float y = Input.GetAxisRaw("Vertical") * speed;
        //groundcheck
        Grounded = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), 0.4f, layerMask);
        //jump
        if (Input.GetKeyDown(KeyCode. Space) && Grounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
        //mov
        Vector3 movPos = transform.right * x + transform.forward * y;
        Vector3 newMovPos = new Vector3(movPos.x, rb.velocity.y, movPos.z);
        rb.velocity = newMovPos;

        GameManager.instance.pos = transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DarkSide"))
        {
            darkSide = true;
        }
        if (other.CompareTag("Simulation"))
        {
            simulation = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("DarkSide"))
        {
            darkSide = false;
        }
        if (other.CompareTag("Simulation"))
        {
            simulation = false;
        }
    }
}
