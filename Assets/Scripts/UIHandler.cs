using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHandler : MonoBehaviour
{
    //countdown text
    public TMP_Text countDown;
    public ParticleSystem pixelExplosion;

    //score
    public TMP_Text score;

    //timer
    public TMP_Text timer;

    [Header("End screen")]
    public GameObject EndScreen;
    public TMP_Text EndTimer;
    public TMP_Text EndScore;

    void Start()
    {
        timer.text = "0:00";
        score.text = "0";
    }

    //set timer value
    public void SetTimerValue(float time)
    {
        float min = Mathf.FloorToInt((time + 1) / 60);
        float sec = Mathf.FloorToInt((time + 1) % 60);
        timer.text = string.Format("{0:00}:{1:00}", min, sec);
    }

    //set timer value
    public void SetScore(float scoreVal)
    {
        score.text = scoreVal.ToString();
    }

    //set count down text
    public void SetCountDown(string text)
    {
        countDown.text = text;
    }

    //disable countdown text
    public void DisableCountDown()
    {
        //pixelExplosion.Play(true);
        countDown.text = "";
    }

    //end game screen
    public void ActivateEndGameScreen(float scoreVal, float time)
    {
        EndScreen.SetActive(true);

        EndScore.text= "Score:"+ scoreVal.ToString();
        float min = Mathf.FloorToInt((time + 1) / 60);
        float sec = Mathf.FloorToInt((time + 1) % 60);
        EndTimer.text = "Time:" + string.Format("{0:00}:{1:00}", min, sec);
    }

}
