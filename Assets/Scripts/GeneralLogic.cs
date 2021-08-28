using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;

//which state game is in
public enum GameState
{
    Starting,
    Paused,
    Running,
    GameOver
}

public class GeneralLogic : MonoBehaviour
{
    public Material groundMaterial;

    //timer for runtime
    private float playTimer;

    //score of player
    private float score;
    public int scoreValue = 5;
    private float lastScoreUpdate = 1f;

    //lives that player has
    public int lives;

    //bonuspooint value
    public int BonusValue=10;
    public int BigBonusMultiplier = 4;

    //current state of game
    private GameState currentState;

    //lives
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    private int visibleHearts = 3;

    //UI reference
    public UIHandler UI;

    //refrence to levelspawner
    public LevelSpawner levelSpawner;

    public AudioSource countDown;
    public AudioSource music;
    public AudioSource health;
    public AudioSource bonusAudio;

    public UnityEngine.XR.Interaction.Toolkit.XRController xrController;
    public UnityEngine.XR.Interaction.Toolkit.XRController xrController2;


    void Update()
    {
        if (currentState == GameState.Running)
        {
            //change score/timer accordingly
            playTimer += Time.deltaTime;

            if (Time.time - lastScoreUpdate >= 0.1f)
            {
                score += scoreValue;
                lastScoreUpdate = Time.time;
                UI.SetScore(score);
            }

            //set UI's
            UI.SetTimerValue(playTimer);
        }
    }

    void Start()
    {
        groundMaterial.SetInt("_GameGoing", 0);
        currentState = GameState.Starting;
        //lives = 1;

        //count down
        StartCoroutine(CountDownTimer()); 
    }

    //start the running
    void StartRunning()
    {
        groundMaterial.SetInt("_GameGoing", 1);
        currentState = GameState.Running;
        levelSpawner.StartRunning();
    }



    //when loosing a live
    public void LoseLife()
    {
        xrController2.SendHapticImpulse(1.0f, 0.1f);
        xrController.SendHapticImpulse(1.0f, 0.1f);

        health.Play(0);
        lives -= 1;
        if (visibleHearts==3 && lives ==2)
        {
            visibleHearts -= 1;
            heart3.SetActive(false);
        }
        if (visibleHearts == 2 && lives == 1)
        {
            visibleHearts -= 1;
            heart2.SetActive(false);
        }
        if (visibleHearts == 1 && lives == 0)
        {
            visibleHearts -= 1;
            heart1.SetActive(false);
        }


        if (lives <=0)
        {
            EndGame();
        }
    }
   
    //when getting life
    public void GetExtraLife()
    {
        lives += 1;
    }

    //pause game
    void PauseGame()
    {
        currentState = GameState.Paused;
        levelSpawner.StopRunning();
    }

    //continue game
    void ContinueGame()
    {
        currentState = GameState.Running;
        levelSpawner.ContinueRunning();
    }

    //continue game
    void EndGame()
    {
        groundMaterial.SetInt("_GameGoing", 0);
        currentState = GameState.GameOver;
        levelSpawner.StopRunning();

        //game over screen
        UI.ActivateEndGameScreen(score, playTimer); 
    }

    //loads the scene again
    public void ReStart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    //Bonus point collection
    public void CollectBonusPoint(int type)
    {
        bonusAudio.Play();
        if (type==1)
        {
            score = score + BonusValue;
        }
        else
        {
            score =score + (BonusValue * BigBonusMultiplier);
        }
    }




    //Coroutine for the start count down
    IEnumerator CountDownTimer()
    {
        countDown.Play(0);
        //TODO audio countdown
        UI.SetCountDown("3");
        yield return new WaitForSeconds(1);
        UI.SetCountDown("2");
        yield return new WaitForSeconds(1);
        //UI.SetCountDown("1");
        yield return new WaitForSeconds(1);
        UI.SetCountDown("Run!");
        music.Play(0);
        StartRunning();
        yield return new WaitForSeconds(1);
        UI.DisableCountDown();
    }
}
