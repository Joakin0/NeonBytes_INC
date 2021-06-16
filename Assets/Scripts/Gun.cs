using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage;
    public float range;
    public float fireRate;
    public float impactForce;

    public int maxAmmo = 1;
    private int currentAmmo;
    public float reloadTime;

    public Camera fpsCam;
    public ParticleSystem flashFX;
    public GameObject impactFX;

    private float timeToFire = 0f;

    private void Start()
    {
        currentAmmo = maxAmmo;
    }

    private void Update()
    {
        if (currentAmmo <= 0 || Input.GetKeyDown(KeyCode.R))
        {
            Reload();
            return;
        }
        if(Input.GetButton("Fire1") && Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }
    void Shoot()
    {
        flashFX.Play();

        currentAmmo--;

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Health health = hit.transform.GetComponent<Health>();
            if(health != null)
            {
                health.TakeDamage(damage);
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            GameObject impact = Instantiate(impactFX, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 1f);
        }
    }
    void Reload()
    {
        Debug.Log("Reloading...");
        currentAmmo = maxAmmo;
    }
}
