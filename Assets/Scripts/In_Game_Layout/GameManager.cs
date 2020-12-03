using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int experienceScore_Mission1;
    public int reputationScore_Mission1;
    public float money_Mission1;
    public float TimeOfMission_Minutes = 1;
    public float ExtendTimerOf_Minutes = 1;
    public int MaxNumberOfPopUp = 7;
    public int MinNumberOfPopUp = 3;

    // ideal (maximum) reputation, experience, and money that can be obtained from this mission
    public float idealReputation = 100.0f;
    public float idealExperience = 100.0f;
    public float idealMoney = 100.0f;

    public GameObject redundancy;
    public GameObject reliability;
    public GameObject clarity;
    public GameObject efficiency;
    public GameObject innovation;
    public GameObject progressbar;

    public int redundancyScore;
    public int reliabilityScore;
    public int clarityScore;
    public int efficiencyScore;
    public int innovationScore;
    public int progressbarScore;

    public Button finishMissionButton;

    private int overallProductScore;
    public int idealOverallProductScore = 750;
    private float failureProbability;

    //completed tasks
    public List<string> CompletedTasks;
    public int numberOfTasks;
    private float CompletedtasksRatioPenalty;

    // Start is called before the first frame update
    void Start()
    {
        reputationScore_Mission1 = 0;
        experienceScore_Mission1 = 0;

        UpdateTheScore();

        Time.timeScale = 1f;
    }

    //timer
    public void Update()
    {
        UpdateTheScore();
    }

    //this function is used to set the timer of the mission
    public int CalculateTimeInSeconds(float timeInMinutes)
    {
        int timeInSeconds = (int)(timeInMinutes * 60.0f);
        return timeInSeconds;
    }

    private void UpdateTheScore()
    {
        redundancy.GetComponent<ProgressBar>().current = redundancyScore;
        reliability.GetComponent<ProgressBar>().current = reliabilityScore;
        clarity.GetComponent<ProgressBar>().current = clarityScore;
        efficiency.GetComponent<ProgressBar>().current = efficiencyScore;
        innovation.GetComponent<ProgressBar>().current = innovationScore;
        progressbar.GetComponent<ProgressBar>().current = progressbarScore;
    }

    public void CompleteLevel()
    {
        finishMissionButton.gameObject.SetActive(true);
    }
    public void NotCompleteLevel()
    {
        finishMissionButton.gameObject.SetActive(false);
    }

    public float  CalculateFailureProbability()
    {
        overallProductScore = redundancyScore + reliabilityScore + clarityScore + efficiencyScore + innovationScore;

        float diffScore = (float)overallProductScore / (float)idealOverallProductScore;

        if (diffScore > 1.2f)
        {
            failureProbability = 5.0f;
        }
        else if (diffScore > 1.0f && diffScore <= 1.2f)
        {
            failureProbability = 10.0f;
        }
        else if (diffScore > 0.8f && diffScore <= 1.0f)
        {
            failureProbability = 20.0f;
        }
        else if (diffScore > 0.6f && diffScore <= 0.8f)
        {
            failureProbability = 40.0f;
        }
        else if (diffScore > 0.4f && diffScore <= 0.6f)
        {
            failureProbability = 60.0f;
        }
        else if (diffScore <= 0.4f)
        {
            failureProbability = 85.0f;
        }

        return failureProbability;
    }

    public void DetermineMissionSuccess()   // eventually this will display (at least) two different text -- one for pass, one for fail
    {
        int failureProbabilityScore = UnityEngine.Random.Range(1, 101);    //assuming that 0-100 have equally chances of being selected
        if (failureProbabilityScore <= failureProbability)
        {
            Debug.Log("You FAILED, Loser!");
        }
        else
        {
            Debug.Log("You lucky bastard.");
        }
    }

    public float CheckTaskCompleted()
    {
        float CompletedTasksRatio = (float)CompletedTasks.Count / (float)numberOfTasks;

        if (CompletedTasksRatio >= 1.0f)
        {
            CompletedtasksRatioPenalty = 1.0f;
        }
        else if(CompletedTasksRatio < 1.0f && CompletedTasksRatio >= 0.85f)
        {
            CompletedtasksRatioPenalty = CompletedTasksRatio;
        }
        else if(CompletedTasksRatio < 0.85f && CompletedTasksRatio >= 0.75f)
        {
            CompletedtasksRatioPenalty = 0.75f;
        }
        else if(CompletedTasksRatio < 0.75f && CompletedTasksRatio >= 0.70f)
        {
            CompletedtasksRatioPenalty = 0.7f;
        }
        else if(CompletedTasksRatio < 0.70f && CompletedTasksRatio >= 0.55f)
        {
            CompletedtasksRatioPenalty = 0.5f;
        }
        else if(CompletedTasksRatio < 0.55f)
        {
            CompletedtasksRatioPenalty = 0.15f;
        }

        return CompletedtasksRatioPenalty;
    }

    public void DetermineMissionComment()
    {
        CalculateFailureProbability();
        CheckTaskCompleted();

        if (CompletedtasksRatioPenalty >= 0.85f)
        {
            if(failureProbability <= 20.0f)
            {
                Debug.Log("did a good job Motherfucker");
            }
            else if (failureProbability == 40.0f)
            {
                Debug.Log("did a meh job Motherfucker");
            }
            else if (failureProbability == 60.0f)
            {
                Debug.Log("did a bad job Motherfucker");
            }
            else if (failureProbability == 85.0f)
            {
                Debug.Log("that was baaaaaaaaddddd");
            }
        }
        else if (CompletedtasksRatioPenalty < 0.85f && CompletedtasksRatioPenalty >= 0.7f)
        {
            if (failureProbability <= 20.0f)
            {
                Debug.Log("did a meh job Motherfucker");
            }
            else if (failureProbability == 40.0f)
            {
                Debug.Log("did a bad job Motherfucker");
            }
            else if (failureProbability == 60.0f)
            {
                Debug.Log("that was baaaaaaaaddddd");
            }
            else if (failureProbability == 85.0f)
            {
                Debug.Log("WTF are you serious, this was shit");
            }
        }
        else if (CompletedtasksRatioPenalty == 0.5f)
        {
            if (failureProbability <= 20.0f)
            {
                Debug.Log("that was baaaaaaaaddddd");
            }
            else if (failureProbability == 40.0f)
            {
                Debug.Log("WTF are you serious, this was shit");
            }
            else if (failureProbability >= 60.0f)
            {
                Debug.Log("yooo this was the worst shit I have ever seen in my life");
            }
        }
        else if (CompletedtasksRatioPenalty == 0.15f)
        {
            if (failureProbability <= 20.0f)
            {
                Debug.Log("WTF are you serious, this was shit");
            }
            else if (failureProbability >= 40.0f)
            {
                Debug.Log("yooo this was the worst shit I have ever seen in my life");
            }
        }
    }

    public void CalculateReputation()
    {
        reputationScore_Mission1 = (int)((idealReputation * (1 - (failureProbability/100))) * CheckTaskCompleted());
    }

    public void CalculateExperience()
    {
        experienceScore_Mission1 = (int)((idealExperience * (1 - (failureProbability / 100))) * CheckTaskCompleted());
    }

    public void MoneyGained()
    {
        money_Mission1 = (idealMoney * (1 - (failureProbability / 100))) * CheckTaskCompleted();
    }

    public void BackToHome()
    {
        string[] charGeneralName = { "Manager", "Team Member 1", "Team Member 2", "Team Member 3", "Team Member 4" };
        foreach (string character in charGeneralName)
        {
            GameObject.Find("Canvas").transform.Find("Character Info Panel").GetComponent<ConfirmedCharacterInfoList>().SaveCharacterInfo(character);
        }
        //Debug.Log("Character stats saved.");

        SceneManager.LoadScene("In_Game_Home");
    }

    public void Time_Zero()
    {
        Time.timeScale = 0f;
    }
}
