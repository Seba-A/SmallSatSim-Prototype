using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputeProductStats : MonoBehaviour
{
    private GameManager AddTo;

    // Start is called before the first frame update
    void Start()
    {
        AddTo = FindObjectOfType<GameManager>();
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

    public float ScorePenalty(int CharStat, int IdealStat)
    {
        float ratioStat = (float)CharStat / (float)IdealStat;
        float ratioToMultiply = 1;

        if (ratioStat > 0.0f && ratioStat <= 0.3f)
        {
            ratioToMultiply = 0.3f;         // lower cap
        }
        else if (ratioStat > 0.3f && ratioStat <= 1.0f)
        {
            ratioToMultiply = ratioStat;
        }
        else if (ratioStat > 1.0f && ratioStat <= 1.2)
        {
            ratioToMultiply = 1.1f;
        }
        else if (ratioStat > 1.2f && ratioStat <= 1.5f)
        {
            ratioToMultiply = 1.3f;
        }
        else if (ratioStat > 1.5f && ratioStat <= 1.7f)
        {
            ratioToMultiply = 1.5f;
        }
        else if (ratioStat > 1.7f)
        {
            ratioToMultiply = 1.7f;         // upper cap
        }

        return ratioToMultiply;
    }

    // compute ratio first, then average
    public float ComputeAverage(string statToBeComputed)
    {
        float avgMultiplier = 1.0f;

        int charSpeed = 60, charQuality = 60, charRelationship = 60, charFocus = 60, charCreativity = 60;

        int idealSpeed = gameObject.GetComponent<TaskV2>().idealTaskSpeed;
        int idealQuality = gameObject.GetComponent<TaskV2>().idealTaskQuality;
        int idealRelationship = gameObject.GetComponent<TaskV2>().idealTaskRelationship;
        int idealFocus = gameObject.GetComponent<TaskV2>().idealTaskFocus;
        int idealCreativity = gameObject.GetComponent<TaskV2>().idealTaskCreativity;

        switch (statToBeComputed)
        {
            case "Redundancy":

                break;
            case "Reliability":

                break;
            case "Clarity":

                break;
            case "Efficiency":

                break;
            case "Innovation":

                break;
            case "TaskTime":
                // character +speed and +focus
                

                avgMultiplier = (ScorePenalty(charSpeed, idealSpeed) + ScorePenalty(charFocus, idealFocus))/ 2;
                break;
        }

        return avgMultiplier;
    }
}
