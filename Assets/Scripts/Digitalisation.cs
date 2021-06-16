using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digitalisation : MonoBehaviour
{
    public Transform transTo;
    //public float timer = 5f;

    public void Start()
    {
        //Destroy(gameObject, timer);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.transform.position = transTo.transform.position;
            Destroy(gameObject);
        }
    }
}
