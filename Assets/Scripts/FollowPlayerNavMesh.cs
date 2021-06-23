using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayerNavMesh : MonoBehaviour
{
    public NavMeshAgent theAgent;
    // Start is called before the first frame update
    void Start()
    {
        //Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        //theAgent.SetDestination(player.position);
    }

    // Update is called once per frame
    void Update()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        theAgent.SetDestination(player.position);
    }
}
