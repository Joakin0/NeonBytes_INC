using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{

    public Transform player, eyes, canon;

    private NavMeshAgent enemy;

    public SphereCollider zonaVisible;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;


    private void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if(player != null)
        {
            if (PlayerIsInZone())
            {
                enemy.SetDestination(player.position);
                AttackPlayer();
            }
        }
    }
    bool PlayerIsInZone()
    {
        bool playerInZone = false;
        Vector3 difference = (player.transform.position - eyes.transform.position).normalized;
        Debug.DrawRay(eyes.position, difference * zonaVisible.radius);
        RaycastHit hit;

        if (Physics.Raycast(eyes.position, difference, out hit, zonaVisible.radius));
        {
            if(hit.transform.CompareTag("Player"))
            playerInZone = true;
        }
        return playerInZone;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
        }
    }
    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        //enemy.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            ///Attack code here
            Rigidbody rb = Instantiate(projectile, canon.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

}
