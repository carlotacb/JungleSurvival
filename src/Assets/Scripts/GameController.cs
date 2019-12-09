using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Image[] Hearts;
    public int livesRemaining;
    // Start is called before the first frame update
    void Start()
    {
        livesRemaining = 3;
    }

    // Update is called once per frame
    void Update()
    {
        //check remaining lives
        for(var i = 0; i < Hearts.Length; ++i){
            
        }
    }
}
