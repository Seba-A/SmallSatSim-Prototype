using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerBar : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject timerBar;

    public float timeRemaining;
    
    // Start is called before the first frame update
    void Start()
    {
        timerBar.GetComponent<ProgressBar>().maximum = gameManager.CalculateTimeInSeconds();
        timerBar.GetComponent<ProgressBar>().current = timerBar.GetComponent<ProgressBar>().maximum;
        timeRemaining = (float)timerBar.GetComponent<ProgressBar>().current;

        //Debug.Log("this is the maximum value " + timerBar.GetComponent<ProgressBar>().maximum);
        //Debug.Log("this is the current value " + timerBar.GetComponent<ProgressBar>().current);
        //Debug.Log(timerBar.GetComponent<ProgressBar>().maximum);
    }

    // Update is called once per frame
    void Update()
    {
        TimerForTimeBar();
    }

    void TimerForTimeBar()
    {
        if (timeRemaining > 0.0f)
        {
            timeRemaining -= Time.deltaTime;

            //Debug.Log("time left " + timeRemaining);
        }
        else
        {
            timeRemaining = 0;
            Debug.Log("You're out of time");

            //activate UI to give the player choice to get a penalty and continue or to just end the mission
        }

        timerBar.GetComponent<ProgressBar>().current = (int)timeRemaining;
        Debug.Log(timerBar.GetComponent<ProgressBar>().current);
    }
}
