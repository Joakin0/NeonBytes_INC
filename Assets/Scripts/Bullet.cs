using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float damage;
    public float impactForce;
    public Vector3 hitPoint;
    public GameObject impactFX;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody>().AddForce((hitPoint - this.transform.position).normalized * speed);
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<Health>().health -= damage;
            GameObject impact = Instantiate(impactFX, this.transform.position, this.transform.rotation);
            impact.transform.parent = col.transform;
            Destroy(this.gameObject, 1f);
        }
        if (col.collider)
        {
            Destroy(gameObject);
        }
    }
}
