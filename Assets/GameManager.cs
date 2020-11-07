using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI time;
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public bool taskCompleted = false;

    public GameObject redundancy;
    public GameObject reliability;
    public GameObject clarity;
    public GameObject efficiency;
    public GameObject innovation;
    public GameObject progressbar;

    // Start is called before the first frame update
    void Start()
    {
        // will need to change this so that is is true only when task is dragged
        timerIsRunning = true;

        //call the score of each progress bar
        int redundancyScore = 0;
        redundancy.GetComponent<ProgressBar>().current = redundancyScore;

        int reliabilityScore = 0;
        reliability.GetComponent<ProgressBar>().current = reliabilityScore;

        int clarityScore = 0;
        clarity.GetComponent<ProgressBar>().current = clarityScore;

        int efficiencyScore = 0;
        efficiency.GetComponent<ProgressBar>().current = efficiencyScore;

        int innovationScore = 0;
        innovation.GetComponent<ProgressBar>().current = innovationScore;

        int progressbarScore = 0;
        progressbar.GetComponent<ProgressBar>().current = progressbarScore;
    }

    //timer
    public void Update()
    {
        if (timerIsRunning)
        {
            time.text = "Time: " + timeRemaining.ToString("0");

            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("The Task has been completed!");
                timeRemaining = 0;
                timerIsRunning = false;
                taskCompleted = true;
                AddScore();
            }
        }
    }

    private void AddScore()
    {
        throw new NotImplementedException();
    }
}
