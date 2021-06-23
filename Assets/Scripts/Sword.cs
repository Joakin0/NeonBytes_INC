using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public GameObject simPortal;
    public GameObject digPortal;
    public Movment mov;

    public float damage;
    public float range;
    public float fireRate;
    public float impactForce;
    public Camera fpsCam;

    public Animator animator;

    private void Start()
    {
        mov = FindObjectOfType<Movment>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.Play("Katana Attack");
            Attack();
            return;

        }
        if (Input.GetButtonDown("Fire2") && mov.simulation)
        {
            GameObject portal1 = Instantiate(simPortal);
            portal1.transform.position = transform.position + transform.forward;
            portal1.GetComponent<Digitalisation>().transTo = GameObject.FindGameObjectWithTag("digpos").transform;
        }
        if (Input.GetButtonDown("Fire2") && mov.darkSide)
        {
            GameObject portal2 = Instantiate(digPortal);
            portal2.transform.position = transform.position + transform.forward;
            portal2.GetComponent<Digitalisation>().transTo = GameObject.FindGameObjectWithTag("simpos").transform;
        }
    }
    void Attack()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Health health = hit.transform.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }
    }
}
