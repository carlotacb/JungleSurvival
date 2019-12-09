using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{
    Transform player;
    NavMeshAgent nav;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent <NavMeshAgent> ();
        nav.enabled = true;
    }

    void Update()
    {
        nav.SetDestination (player.position);
    }
}
