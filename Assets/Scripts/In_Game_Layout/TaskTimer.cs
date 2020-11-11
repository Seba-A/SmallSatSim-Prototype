using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskTimer : MonoBehaviour
{
    public TextMeshProUGUI time;
    public float timeRemaining;

    public GameObject assignTaskPanel;

    //private Slottable_Assign slottable_Assign;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = gameObject.GetComponent<TaskV2>().timeRequired;
        //slottable_Assign = GameObject.FindObjectOfType<Slottable_Assign>();
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
                Destroy(gameObject);
            }
        }
    }

    /*//increase the score value
    public void AddScore()
    {
        //increase the value of the scores
        GameObject.Find("Game Manager").GetComponent<GameManager>().redundancyScore =+ redundancyScore
        redundancyScore =+ redundancyScore;
        reliabilityScore = +reliabilityScore;
        clarityScore = +clarityScore;
        efficiencyScore = +efficiencyScore;
        innovationScore = +innovationScore;
        progressbarScore = +progressbarScore;
    }*/
}
