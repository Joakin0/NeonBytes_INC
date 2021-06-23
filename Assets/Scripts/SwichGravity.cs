using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwichGravity : MonoBehaviour
{
    private Transform trans;
    private Rigidbody rb;
    public bool changeGravity;
    public float spinSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        changeGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (changeGravity == true)
        {
            Physics.gravity = new Vector3(0, 9.81f, 0);
            transform.Rotate(0, 0, 180);
        }
        if (changeGravity == false)
        {
            Physics.gravity = new Vector3(0, -9.81f, 0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GravityOff"))
        {
            changeGravity = true;
        }
        if (other.CompareTag("GravityOn"))
        {
            changeGravity = false;
        }
    }
}
