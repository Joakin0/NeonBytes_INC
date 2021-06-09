using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwichGravity : MonoBehaviour
{
    private Transform transform;
    private Rigidbody rb;
    public bool changeGravity;
    public float spinspeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        changeGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && changeGravity == false)
        {
            changeGravity = true;
        }
        else if (Input.GetKeyDown(KeyCode.Q) && changeGravity == true)
        {
            changeGravity = false;
        }
            if (changeGravity == true)
        {
            Physics.gravity = new Vector3(0, 9.81f, 0);
        }
        if (changeGravity == false)
        {
            Physics.gravity = new Vector3(0, -9.81f, 0);
        }
    }
}
