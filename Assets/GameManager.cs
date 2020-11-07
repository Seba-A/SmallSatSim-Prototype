using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI time;
    public float timeRemaining;
    public bool timerIsRunning = false;
    public bool taskCompleted = false;

    public GameObject redundancy;
    public GameObject reliability;
    public GameObject clarity;
    public GameObject efficiency;
    public GameObject innovation;
    public GameObject progressbar;

    private int redundancyScore;
    private int reliabilityScore;
    private int clarityScore;
    private int efficiencyScore;
    private int innovationScore;
    private int progressbarScore;

    public Task task1;

    // Start is called before the first frame update
    void Start()
    {
        // will need to change this so that is is true only when task is dragged
        timeRemaining = task1.timeRequired;
        timerIsRunning = true;

        //set the score of each progress bar to 0 at the satr of the game
        redundancyScore = 0;
        redundancy.GetComponent<ProgressBar>().current = redundancyScore;

        reliabilityScore = 0;
        reliability.GetComponent<ProgressBar>().current = reliabilityScore;

        clarityScore = 0;
        clarity.GetComponent<ProgressBar>().current = clarityScore;

        efficiencyScore = 0;
        efficiency.GetComponent<ProgressBar>().current = efficiencyScore;

        innovationScore = 0;
        innovation.GetComponent<ProgressBar>().current = innovationScore;

        progressbarScore = 0;
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

    public void AddScore()
    {
        redundancyScore = task1.redundancy;
        redundancy.GetComponent<ProgressBar>().current = redundancyScore;

        reliabilityScore = 150;
        reliability.GetComponent<ProgressBar>().current = reliabilityScore;

        clarityScore = 300;
        clarity.GetComponent<ProgressBar>().current = clarityScore;

        efficiencyScore = 70;
        efficiency.GetComponent<ProgressBar>().current = efficiencyScore;

        innovationScore = 220;
        innovation.GetComponent<ProgressBar>().current = innovationScore;

        progressbarScore = 90;
        progressbar.GetComponent<ProgressBar>().current = progressbarScore;
    }


}
