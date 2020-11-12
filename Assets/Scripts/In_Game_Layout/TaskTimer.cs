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

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = gameObject.GetComponent<TaskV2>().timeRequired;

        AddTo = FindObjectOfType<GameManager>();
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
                Destroy(gameObject);
            }
        }
    }

    //increase the score value by the task's indicated values
    public void AddScore()
    {
        //increase the value of the scores
        AddTo.redundancyScore = AddTo.redundancyScore + gameObject.GetComponent<TaskV2>().redundancy;
        AddTo.reliabilityScore = AddTo.reliabilityScore + gameObject.GetComponent<TaskV2>().reliability;
        AddTo.clarityScore = AddTo.clarityScore + gameObject.GetComponent<TaskV2>().clarity;
        AddTo.efficiencyScore = AddTo.efficiencyScore + gameObject.GetComponent<TaskV2>().efficiency;
        AddTo.innovationScore = AddTo.innovationScore + gameObject.GetComponent<TaskV2>().innovation;
        AddTo.progressbarScore = AddTo.progressbarScore + gameObject.GetComponent<TaskV2>().progressbar;
    }
}
