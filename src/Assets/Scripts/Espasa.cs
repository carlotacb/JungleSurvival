using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espasa : MonoBehaviour
{
    Ray shootRay;                                   // A ray from the gun end forwards.
    RaycastHit shootHit;                            // A raycast hit to get information about what was hit.
    int shootableMask;                              // A layer mask so the raycast only hits things on the shootable layer.
    AudioSource espasaAudio;                        // Reference to the audio source.

    void Awake ()
    {
        // Create a layer mask for the Shootable layer.
        shootableMask = LayerMask.GetMask ("Shootable");

        // Set up the references.
        espasaAudio = GetComponent<AudioSource> ();
    }

    void Update ()
    {
        // Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        // Perform the raycast against gameobjects on the shootable layer and if it hits something...
        if(Physics.Raycast (shootRay, out shootHit, shootableMask))
        {
            // Try and find an EnemyHealth script on the gameobject hit.
            ZombieDeath enemyHealth = shootHit.collider.GetComponent <ZombieDeath> ();

            // If the EnemyHealth component exist...
            if(enemyHealth != null)
            {
                // ... the enemy should take damage.
                enemyHealth.Death();
            }
        }
        espasaAudio.Play();
    }
}
