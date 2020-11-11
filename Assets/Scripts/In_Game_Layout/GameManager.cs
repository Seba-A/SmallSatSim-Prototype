using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
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

    // Start is called before the first frame update
    void Start()
    {
        // will need to change this so that is is true only when task is dragged
        //timeRemaining = 15;
        //timerIsRunning = true;

        //set the score of each progress bar to 0 at the satr of the game
        redundancyScore = 100;
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
        /*
        //need to find a way to do it for any task
        if (GameObject.Find("Task") != null)
        {
            if (GameObject.Find("Task").GetComponent<Draggable>().timerIsRunning)
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
                    GameObject.Find("Task").GetComponent<Draggable>().taskCompleted = true;
                    //Destroy(GameObject.Find("Task"));
                    AddScore();
                }

        if (assignedTaskContent.GetComponent<Slottable>().isTaskSlotted == true)
        {
            string currentRunningTask = assignedTaskContent.GetComponent<Slottable>().slottedTaskName;
            Debug.Log(currentRunningTask);

            time.text = "Time: " + timeRemaining.ToString("0");

            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("The Task has been completed!");
                timeRemaining = 0;
                //GameObject.Find(currentRunningTask).GetComponent<Draggable>().timerIsRunning = false;
                Destroy(GameObject.Find(currentRunningTask));
                AddScore();
            }
        }*/
    }

    public void AddScore()
    {
        //redundancyScore += GameObject.Find(currentRunningTask).redundancyScoreToAdd;

        redundancyScore = 50;
        redundancy.GetComponent<ProgressBar>().current =+ redundancyScore;

        reliabilityScore = 150;
        reliability.GetComponent<ProgressBar>().current =+ reliabilityScore;

        clarityScore = 300;
        clarity.GetComponent<ProgressBar>().current =+ clarityScore;

        efficiencyScore = 70;
        efficiency.GetComponent<ProgressBar>().current =+ efficiencyScore;

        innovationScore = 220;
        innovation.GetComponent<ProgressBar>().current =+ innovationScore;

        progressbarScore = 90;
        progressbar.GetComponent<ProgressBar>().current =+ progressbarScore;
    }
}
