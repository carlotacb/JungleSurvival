using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 2f;      // The time in seconds between each attack.

    Animator anim;                              // Reference to the animator component.
    GameObject player;                          // Reference to the player GameObject.
    bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
    float timer;                                // Timer for counting up to the next attack.
    GameController gameController;
    SceneController sceneController;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        anim = GetComponent <Animator> ();
        sceneController = GetComponent <SceneController> ();
    }


    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = true;
        }
    }


    void OnTriggerExit (Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = false;
        }
    }


    void Update ()
    {
        timer += Time.deltaTime;

        if(timer >= timeBetweenAttacks && playerInRange)
        {
            Attack ();
        }

        if(sceneController.remainingLife <= 0)
        {
            sceneController.showEndGame();
        }
    }


    void Attack ()
    {
        timer = 0f;

        if(sceneController.remainingLife > 0)
        {
            anim.SetTrigger("ZombieAttack");
            // sceneController.attacked();
        }
    }
}
