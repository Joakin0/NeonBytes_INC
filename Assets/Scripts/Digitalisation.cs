using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digitalisation : MonoBehaviour
{
    public Transform portal;

    public void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.transform.position = portal.transform.position;
            //Destroy(gameObject);
        }
    }
}
