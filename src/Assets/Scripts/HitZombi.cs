using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitZombi : MonoBehaviour
{
    public SceneController sceneController;

    void onTriggerEnter(Collider col){
        sceneController.onHit();
    }
}
