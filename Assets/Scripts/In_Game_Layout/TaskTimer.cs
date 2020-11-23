using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskTimer : MonoBehaviour
{
    public TextMeshProUGUI time;
    public float timeRemaining;

    public GameObject assignTaskPanel;

    private GameManager AddTo;

    public bool FirstTimeCompletion = false;

    // return to task list once the task is completed and tick that will have to activate once the task has been completed the first time
    public Transform parentToReturnToOnceCompleted;
    public GameObject FirstCompletionTick;

    //private StatsDisplay statsDisplay;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = gameObject.GetComponent<TaskV2>().timeRequired;

        AddTo = FindObjectOfType<GameManager>();

        //Parent that the task has to return to once it has been completed
        parentToReturnToOnceCompleted = this.transform.parent;

        //statsDisplay = FindObjectOfType<StatsDisplay>();
    }

    void Update()
    {
        TaskTime();
    }

    // The timer is set
    public void TaskTime()
    {
        if (gameObject.GetComponent<Draggable>().taskIsAssigned)
        {
            time.text = "Time: " + timeRemaining.ToString("0");

            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                assignTaskPanel.GetComponent<Slottable_Assign>().startNextTask = false;
                //slottable_Assign.startNextTask = false;
            }
            else
            {
                //Debug.Log("Time has run out!");
                timeRemaining = 0;
                gameObject.GetComponent<TaskV2>().taskCompleted = true;
                assignTaskPanel.GetComponent<Slottable_Assign>().startNextTask = true;
                //slottable_Assign.startNextTask = true;
                assignTaskPanel.GetComponent<Slottable_Assign>().tasks.Remove(gameObject.name);
                AddScore();
                ScorePenalty();

                //return task to task list and set tick true
                this.transform.SetParent(parentToReturnToOnceCompleted);
                FirstTimeCompletion = true;
                FirstCompletionTick.SetActive(true);

                //Destroy(gameObject);
            }
        }
    }

    //increase the score value by the task's indicated values
    public void AddScore()
    {
        AddTo.redundancyScore = AddTo.redundancyScore + gameObject.GetComponent<TaskV2>().redundancy;
        AddTo.reliabilityScore = AddTo.reliabilityScore + gameObject.GetComponent<TaskV2>().reliability;
        AddTo.clarityScore = AddTo.clarityScore + gameObject.GetComponent<TaskV2>().clarity;
        AddTo.efficiencyScore = AddTo.efficiencyScore + gameObject.GetComponent<TaskV2>().efficiency;
        AddTo.innovationScore = AddTo.innovationScore + gameObject.GetComponent<TaskV2>().innovation;
        AddTo.progressbarScore = AddTo.progressbarScore + gameObject.GetComponent<TaskV2>().progressbar;
    }

    public void ScorePenalty()
    {
        float myFloat = (float)gameObject.GetComponent<TaskV2>().redundancy + 0.1f;
        Debug.Log("this is a float " + myFloat);
        Debug.Log("this is an int " + (int)myFloat);
    }
}
