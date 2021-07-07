using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    //public UIManager uiManager;
    public float range;
    public float bulletSpeed;
    public float fireRate;
    public float spread;
    public GameObject bullet;
    public GameObject simBullet;
    public GameObject digBullet;
    public Transform aim;
    public int maxAmmo = 6;
    public int currentAmmo = 6;
    public float reloadTime;
    private bool isReloading = false;

    public Camera fpsCam;
    public ParticleSystem flashFX;
    public GameObject impactFX;

    private float timeToFire = 0f;

    public Animator animator;
    public AudioSource sfx;
    public List<AudioClip> clips;

    private void Start()
    {
        currentAmmo = maxAmmo;
    }

    private void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }

    private void Update()
    {
        if (isReloading)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < 6)
        {
            StartCoroutine(Reload());
            sfx.clip = clips[2];
            sfx.Play();
            return;
        }
        if (Input.GetButton("Fire1") && Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
        if (Input.GetButton("Fire2") && Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1f / fireRate;
            SpecialSim();
        }
    }
    void Shoot()
    {
        //uiManager.UIUpdate();
        if (currentAmmo > 0)
        {
            flashFX.Play();
            sfx.clip = clips[0];
            sfx.Play();
        }
        else
        {
            sfx.clip = clips[1];
            sfx.Play();
        }

        currentAmmo--;

        if (currentAmmo > -1)
        {
            Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            Vector3 targetPoint;
            Quaternion fireRotation = Quaternion.LookRotation(transform.forward);
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);
                targetPoint = hit.point;
                //Health health = hit.transform.GetComponent<Health>();
                //if(health != null)
                //{
                //    health.TakeDamage(damage);
                //}
                //if (hit.rigidbody != null)
                //{
                //    hit.rigidbody.AddForce(-hit.normal * impactForce);
                //}
                GameObject impact = Instantiate(impactFX, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impact, 1f);
            }
            else
            {
                targetPoint = ray.GetPoint(100);
            }
            //direccion de la bala
            Vector3 bulletDirection = targetPoint - aim.position;
            //dispercion de las balas
            float spreadX = Random.Range(-spread, spread);
            float spreadY = Random.Range(-spread, spread);
            Vector3 spreadDirection = bulletDirection + new Vector3(spreadX, spreadY, 0);
            //Instancia bullet
            GameObject _bullet = Instantiate(bullet, aim.position, Quaternion.identity);
            _bullet.transform.forward = bulletDirection.normalized;
            _bullet.GetComponent<Rigidbody>().AddForce(bulletDirection.normalized * bulletSpeed, ForceMode.Impulse);
        }
    }
    void SpecialSim()
    {
        //uiManager.UIUpdate();
        if (currentAmmo > 0)
        {
            flashFX.Play();
            sfx.clip = clips[0];
            sfx.Play();
        }
        else
        {
            sfx.clip = clips[1];
            sfx.Play();
        }

        currentAmmo -= 3;

        if (currentAmmo > -1)
        {
            Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            Vector3 targetPoint;
            Quaternion fireRotation = Quaternion.LookRotation(transform.forward);
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);
                targetPoint = hit.point;

                GameObject impact = Instantiate(impactFX, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impact, 1f);
            }
            else
            {
                targetPoint = ray.GetPoint(100);
            }
            Vector3 bulletDirection = targetPoint - aim.position;
            GameObject _bulletSim = Instantiate(simBullet, aim.position, Quaternion.identity);
            _bulletSim.transform.forward = bulletDirection.normalized;
            _bulletSim.GetComponent<Rigidbody>().AddForce(bulletDirection.normalized * bulletSpeed, ForceMode.Impulse);
        }
    }
    void SpecialDig()
    {
        //uiManager.UIUpdate();
        if (currentAmmo > 0)
        {
            flashFX.Play();
            sfx.clip = clips[0];
            sfx.Play();
        }
        else
        {
            sfx.clip = clips[1];
            sfx.Play();
        }

        currentAmmo -= 3;

        if (currentAmmo > -1)
        {
            Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            Vector3 targetPoint;
            Quaternion fireRotation = Quaternion.LookRotation(transform.forward);
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);
                targetPoint = hit.point;

                GameObject impact = Instantiate(impactFX, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impact, 1f);
            }
            else
            {
                targetPoint = ray.GetPoint(100);
            }
            Vector3 bulletDirection = targetPoint - aim.position;
            GameObject _bullet = Instantiate(bullet, aim.position, Quaternion.identity);
            _bullet.transform.forward = bulletDirection.normalized;
            _bullet.GetComponent<Rigidbody>().AddForce(bulletDirection.normalized * bulletSpeed, ForceMode.Impulse);
        }
    }
    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");
        animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadTime - .25f);
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(.25f);
        currentAmmo = maxAmmo;
        isReloading = false;
    }
}
