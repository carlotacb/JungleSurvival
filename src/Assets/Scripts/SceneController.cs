using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public Image[] Hearts;
    public Text counter;
    public Image gameOverImage;
    public Image youWinImage;
    public Text resetText;
    public AudioClip winning_sound;
    public AudioClip gameover_sound;

    public int remainingLife;
    private int numZombies;

    private bool win;
    private bool gameOver;
    private bool resetActive;
    private float timeLeft = 60;
    AudioSource sceneAudio;
    // Start is called before the first frame update
    void Start()
    {
        remainingLife = 3;
        numZombies = 0;
        win = false;
        gameOver = false;
        resetActive = false;
        sceneAudio = GetComponent <AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0) 
        {
            less();
            if (remainingLife >= 1) {
                timeLeft = 60;
            }
        }
        if(resetActive){
            if (GvrControllerInput.AppButtonUp || GvrControllerInput.ClickButtonDown) {
                Scene scene = SceneManager.GetActiveScene(); 
                SceneManager.LoadScene(scene.name);
            }
        }
        else {
            if (numZombies == 10 || remainingLife == 0) showEndGame();
            else {
                //update life
                for (var i = 0; i<Hearts.Length; ++i){
                    IsActive isActive = Hearts[i].GetComponent<IsActive>();
                    if (i < remainingLife) isActive.SetActive(true);
                    else isActive.SetActive(false);
                }
                //update num zombies
                counter.text = numZombies.ToString();
            }
        }
    }

    public void showEndGame(){
        //win or game over
        if(remainingLife==0) {
            gameOver = true;   
            IsActive isActive = gameOverImage.GetComponent<IsActive>();
            sceneAudio.clip = gameover_sound;
            sceneAudio.Play(); 
            isActive.SetActive(true);
        }
        else {
            win = true;
            IsActive isActive = youWinImage.GetComponent<IsActive>();
            sceneAudio.clip = winning_sound;
            sceneAudio.Play();
            isActive.SetActive(true);
        }

        IsActive active = resetText.GetComponent<IsActive>();
        active.SetActive(true);
        resetActive = true;
    }

    public void onHit() {
        numZombies = numZombies + 1;
    }

    void less() {
        remainingLife = remainingLife - 1;
    }

    public bool getState(){
        return win || gameOver;
    }
}
