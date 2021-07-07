using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shooter : MonoBehaviour
{
    //bullet
    public GameObject bullet;

    //bullet force
    public float shootForce, upwardForce;

    //Gun stats
    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazine, bulletsPerTap;
    public bool allowHold;
    int bulletsLeft, bulletShot;

    //bool
    bool shooting, readyToShoot, reloading;

    //reference
    public Camera fpsCam;
    public Transform attackPoint;

    //Graphics & FX
    public ParticleSystem flashFX;
    public TextMeshProUGUI ammoDisplay;
    public Animator animator;
    public AudioSource sfx;
    public List<AudioClip> clips;

    //bug fixing
    public bool allowInvoke = true;

    private void Awake()
    {
        //full magazine in start
        bulletsLeft = magazine;
        readyToShoot = true;
    }
    private void OnEnable()
    {
        reloading = false;
        animator.SetBool("Reloading", false);
    }
    private void Update()
    {
        MyInput();

        //set ammo display
        if (ammoDisplay != null)
            ammoDisplay.SetText(bulletsLeft / bulletsPerTap + " / " + magazine / bulletsPerTap);
    }
    private void MyInput()
    {
        //if allow to hold the trigger
        if (allowHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //reloading
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazine && !reloading)
        {
            StartCoroutine(Reloading());
            Reload();
        }
        //auto-reload
        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0)
        {
            StartCoroutine(Reloading());
            Reload();
        }

        //shooting
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            //set bulletShot to 0
            bulletShot = 0;

            Shoot();
        }
    }
    private void Shoot()
    {
        if (bulletsLeft > 0)
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

        readyToShoot = false;
        //raycast
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        //check raycast hit
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(100);

        //direction
        Vector3 directionBullet = targetPoint - attackPoint.position;

        //spread
        float xSpread = Random.Range(-spread, spread);
        float ySpread = Random.Range(-spread, spread);

        //spread direction
        Vector3 spreedDirection = directionBullet + new Vector3(xSpread, ySpread, 0);

        //Instantiate Bullet
        GameObject _bullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        //rotate bullet
        _bullet.transform.forward = spreedDirection.normalized;

        //add force to bullet
        _bullet.GetComponent<Rigidbody>().AddForce(spreedDirection.normalized * shootForce, ForceMode.Impulse);
        _bullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

        //VFXs


        bulletsLeft--;
        bulletShot++;

        //reset shot funcion
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }
        //if more than one bullet per shot
        if (bulletShot < bulletsPerTap && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }
    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        sfx.clip = clips[2];
        sfx.Play();
        reloading = true;
        Invoke("ReloadFinish", reloadTime);
    }
    private void ReloadFinish()
    {
        bulletsLeft = magazine;
        reloading = false;
    }
    IEnumerator Reloading()
    {
        reloading = true;
        Debug.Log("Reloading...");
        animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadTime - .25f);
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(.25f);
        bulletsLeft = magazine;
        reloading = false;
    }
}  
