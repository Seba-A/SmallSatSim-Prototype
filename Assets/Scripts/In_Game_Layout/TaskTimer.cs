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

    public GameObject MissionPanel;

    //the values below will be used to diminuish the score u get if you kkeep on repeating the same tasks
    private float RepeatPenalty = 1.0f;
    private float IncreaseRepeatPenalty = 0.5f;

    //private StatsDisplay statsDisplay;

    // Start is called before the first frame update
    void Start()
    {
        //timeRemaining = gameObject.GetComponent<TaskV2>().timeRequired;

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
        if (gameObject.GetComponent<TaskAssigned>().taskIsAssigned)
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

                AddScore(RepeatPenalty);
                ScorePenalty();

                //return task to task list and set tick true
                this.transform.SetParent(parentToReturnToOnceCompleted);
                FirstTimeCompletion = true;
                FirstCompletionTick.SetActive(true);

                //reactivate the draggable thing
                (parentToReturnToOnceCompleted.transform.Find(this.transform.name).GetComponent<Draggable>() as MonoBehaviour).enabled = true;

                RepeatPenalty = RepeatPenalty + IncreaseRepeatPenalty;
                //Debug.Log(RepeatPenalty);
            }
        }
    }

    //increase the score value by the task's indicated values
    public void AddScore(float repeatIndex)
    {
        AddTo.redundancyScore = AddTo.redundancyScore + (int)((float)gameObject.GetComponent<TaskV2>().redundancy / repeatIndex);
        AddTo.reliabilityScore = AddTo.reliabilityScore + (int)((float)gameObject.GetComponent<TaskV2>().reliability / repeatIndex);
        AddTo.clarityScore = AddTo.clarityScore + (int)((float)gameObject.GetComponent<TaskV2>().clarity / repeatIndex);
        AddTo.efficiencyScore = AddTo.efficiencyScore + (int)((float)gameObject.GetComponent<TaskV2>().efficiency / repeatIndex);
        AddTo.innovationScore = AddTo.innovationScore + (int)((float)gameObject.GetComponent<TaskV2>().innovation / repeatIndex);
    }

    public void ScorePenalty()
    {
        float myFloat = (float)gameObject.GetComponent<TaskV2>().redundancy + 0.1f;
        //Debug.Log("this is a float " + myFloat);
        //Debug.Log("this is an int " + (int)myFloat);
        int test = (int)(gameObject.GetComponent<TaskV2>().redundancy + ((float)gameObject.GetComponent<TaskV2>().redundancy / 2));
        //Debug.Log("this is a test: " + test);
    }
}
