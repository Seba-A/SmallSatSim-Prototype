using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerBar : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject timerBar;
    public GameObject TimerToZero;
    public GameObject TimeButtons;

    public GameObject NoExtension;
    public GameObject ExtensionButton;

    public bool TimeIsZero = false;
    public bool ExtentionAlreadyGiven = false;
    public bool CloseThisUI = false;

    private float timeRemaining;
    
    // Start is called before the first frame update
    void Start()
    {
        timerBar.GetComponent<ProgressBar>().maximum = gameManager.CalculateTimeInSeconds(gameManager.TimeOfMission_Minutes);
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
        CheckIfTimeIsZero();
    }

    void TimerForTimeBar()
    {
        if (TimeIsZero == false)
        {
            if (timeRemaining > 0.0f)
            {
                timeRemaining -= Time.deltaTime;

                //Debug.Log("time left " + timeRemaining);
            }
            else
            {
                //Debug.Log("You're out of time");
                timeRemaining = 0;
                Time.timeScale = 0f;

                //activate UI to give the player choice to get a penalty and continue or to just end the mission + deactivate the time buttons
                TimeButtons.gameObject.SetActive(false);
                if (ExtentionAlreadyGiven)
                {
                    TimeIsZero = true;
                    ExtensionButton.SetActive(false);
                    NoExtension.SetActive(true);
                }
                else
                {
                    TimeIsZero = true;
                }
            }
        }

        timerBar.GetComponent<ProgressBar>().current = (int)timeRemaining;
        //Debug.Log(timerBar.GetComponent<ProgressBar>().current);
    }

    public void CheckIfTimeIsZero()
    {
        if (TimeIsZero)
        {
            if (CloseThisUI)
            {
                TimerToZero.gameObject.SetActive(false);
            }
            else
            {
                TimerToZero.gameObject.SetActive(true);
            }
        }
        else
        {
            TimerToZero.gameObject.SetActive(false);
        }
    }

    public void EndMissionButton()
    {
        CloseThisUI = true;
    }

    // will need to add something that will work as a penalty
    public void ExtendDeadline()
    {
        timeRemaining = gameManager.CalculateTimeInSeconds(gameManager.ExtendTimerOf_Minutes);
        TimeIsZero = false;
        ExtentionAlreadyGiven = true;
        Time.timeScale = 1f;

        TimeButtons.gameObject.SetActive(true);
    }
}
