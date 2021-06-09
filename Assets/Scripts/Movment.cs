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
    }
}
