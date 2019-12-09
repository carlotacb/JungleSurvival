using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeath : MonoBehaviour
{
    Animator anim;                              // Reference to the animator.
    AudioSource enemyAudio;                     // Reference to the audio source.
    CapsuleCollider capsuleCollider;            // Reference to the capsule collider.
    bool isDead;                                // Whether the enemy is dead.
    SceneController sceneController;

    void Awake ()
    {
        // Setting up the references.
        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();
        sceneController = GetComponent <SceneController> ();
    }

    void Update () { }

    public void Death ()
    {
        isDead = true;
        capsuleCollider.isTrigger = true;
        anim.SetTrigger ("Dead");
        enemyAudio.Play ();
        sceneController.onHit();
        Destroy (gameObject, 5f);
    }
}
