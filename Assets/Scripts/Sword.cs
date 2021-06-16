using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public GameObject simPortal;
    public GameObject digPortal;
    public bool dig;
    public bool sim;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(simPortal);
            simPortal.transform.position = transform.position + transform.forward;
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Instantiate(digPortal);
            digPortal.transform.position = transform.position + transform.forward;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("DarkSide"))
        {
            dig = true;
        }
        if (other.CompareTag("Simulation"))
        {
            sim = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        {
            if (other.CompareTag("DarkSide"))
            {
                dig = false;
            }
            if (other.CompareTag("Simulation"))
            {
                sim = false;
            }
        }
    }
    //void Hability(Vector3 dir)
    //{
    //    GameObject goTo = Instantiate(objeto, transform.position, Quaternion.identity);
    //    goTo.GetComponent<Digitalisation>().PortalDirection(dir);
    //}
}
