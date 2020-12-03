using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int experienceScore_Mission;
    public int reputationScore_Mission;
    public float money_Mission;
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

    private float repeatMissionPenalty = 1.0f;
    private readonly string repeatMissionCount = "NumberOfTimesMissionIsRepeated";

    public TextMeshProUGUI reputationText;
    public TextMeshProUGUI experienceText;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI Pass_Fail;
    public TextMeshProUGUI Comment;


    private void Awake()
    {
        this.GetComponent<UpdateCompanyStats>().ResetCompanyStats();
        this.GetComponent<UpdateProductStats>().ResetProductStats();
        //Debug.Log("All Company and Product Stats are reset.");
    }

    // Start is called before the first frame update
    void Start()
    {
        reputationScore_Mission = 0;
        experienceScore_Mission = 0;

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
        CalculateFailureProbability();
        CheckTaskCompleted();

        int failureProbabilityScore = UnityEngine.Random.Range(1, 101);    //assuming that 0-100 have equally chances of being selected
        if (failureProbabilityScore >= failureProbability)
        {
            if (CompletedtasksRatioPenalty >= 0.85f)
            {
                Pass_Fail.text = "Hello Elon, the mission was completed successfully. But I think you already knew that.";
            }
            else if (CompletedtasksRatioPenalty < 0.85f && CompletedtasksRatioPenalty >= 0.7f)
            {
                Pass_Fail.text = "The mission was completed successfully almost perfect";
            }
            else if (CompletedtasksRatioPenalty == 0.5f)
            {
                Pass_Fail.text = "The mission was completed successfully but some improvements could have been made.";
            }
            else if (CompletedtasksRatioPenalty == 0.15f)
            {
                Pass_Fail.text = "I don't know how but your employer is happy with your work, they must be worst than you. Do not get cocky though, you've just been lucky.";
            }
        }
        else
        {
            if (CompletedtasksRatioPenalty >= 0.85f)
            {
                Pass_Fail.text = "Unfortunately you have failed the mission, even the best of works have a small chance of failing. You might have more luck next time.";
            }
            else if (CompletedtasksRatioPenalty < 0.85f && CompletedtasksRatioPenalty >= 0.7f)
            {
                Pass_Fail.text = "You tried so hard and got so far, but in the end it didn't really matter. You failed my friend.";
            }
            else if (CompletedtasksRatioPenalty == 0.5f)
            {
                Pass_Fail.text = "I guess this should not come as a surprise but the mission had a high chance of failing, and it did. Work harder net time.";
            }
            else if (CompletedtasksRatioPenalty == 0.15f)
            {
                Pass_Fail.text = "Should I really tell you that you have failed. I mean, might aswell just send an apple to space, it would definitely be more useful than this shit.";
            }
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
                Comment.text = "Did a good job Motherfucker, continue like this in your next mission to become successful";
            }
            else if (failureProbability == 40.0f)
            {
                Comment.text = "Did a meh job Motherfucker, try to be more careful when assigning a task to a member of your team, remember that a character's stats will affect how well a task is completed";
            }
            else if (failureProbability == 60.0f)
            {
                Comment.text = "Did a bad job Motherfucker, try to be more careful when assigning a task to a member of your team, remember that a character's stats will affect how well a task is completed";
            }
            else if (failureProbability == 85.0f)
            {
                Comment.text = "That was baaaaaaaaddddd, try to be really more careful when assigning a task to a member of your team, remember that a character's stats will affect how well a task is completed";
            }
        }
        else if (CompletedtasksRatioPenalty < 0.85f && CompletedtasksRatioPenalty >= 0.7f)
        {
            if (failureProbability <= 20.0f)
            {
                Comment.text = "Did a meh job Motherfucker, try to be more careful when assigning a task to a member of your team, remember that a character's stats will affect how well a task is completed. If you manage to time everything so to complete all the tasks to have a greater chance of succeding";
            }
            else if (failureProbability == 40.0f)
            {
                Comment.text = "Did a bad job Motherfucker, try to be more careful when assigning a task to a member of your team, remember that a character's stats will affect how well a task is completed. Try to complete more tasks";
            }
            else if (failureProbability == 60.0f)
            {
                Comment.text = "That was baaaaaaaaddddd, try to be more careful when assigning a task to a member of your team, remember that a character's stats will affect how well a task is completed. Try to complete more tasks";
            }
            else if (failureProbability == 85.0f)
            {
                Comment.text = "WTF are you serious, this was shit, try to be more careful when assigning a task to a member of your team, remember that a character's stats will affect how well a task is completed. Try to complete more tasks";
            }
        }
        else if (CompletedtasksRatioPenalty == 0.5f)
        {
            if (failureProbability <= 20.0f)
            {
                Comment.text = "that was baaaaaaaaddddd, try to be more careful when assigning a task to a member of your team, remember that a character's stats will affect how well a task is completed. The amount of tasks you have completed Is definitely not enought to garantee a high quality product";
            }
            else if (failureProbability == 40.0f)
            {
                Comment.text = "WTF are you serious, this was shit, try to be more careful when assigning a task to a member of your team, remember that a character's stats will affect how well a task is completed. The amount of tasks you have completed Is definitely not enought to garantee a high quality product";
            }
            else if (failureProbability >= 60.0f)
            {
                Comment.text = "yooo this was the worst shit I have ever seen in my life, try to be more careful when assigning a task to a member of your team, remember that a character's stats will affect how well a task is completed. The amount of tasks you have completed Is definitely not enought to garantee a high quality product";
            }
        }
        else if (CompletedtasksRatioPenalty == 0.15f)
        {
            if (failureProbability <= 20.0f)
            {
                Comment.text = "WTF are you serious, this was shit. Well you should really try to assign the tasks better or at least assign some tasks at all.";
            }
            else if (failureProbability >= 40.0f)
            {
                Comment.text = "yooo this was the worst shit I have ever seen in my life. Are you actually planning to fail.";
            }
        }
    }

    public void CalculateReputation()
    {
        reputationScore_Mission = (int)((idealReputation * (1 - (CalculateFailureProbability() / 100))) * CheckTaskCompleted() * GetMissionPenalty(PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + repeatMissionCount)));
    }

    public void CalculateExperience()
    {
        experienceScore_Mission = (int)((idealExperience * (1 - (CalculateFailureProbability() / 100))) * CheckTaskCompleted() * GetMissionPenalty(PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + repeatMissionCount)));
    }

    public void MoneyGained()
    {
        money_Mission = (float)((idealMoney * (1 - (CalculateFailureProbability() / 100))) * CheckTaskCompleted() * GetMissionPenalty(PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + repeatMissionCount)));
    }

    private float GetMissionPenalty(int missionCount)
    {
        switch (missionCount)
        {
            case 0:
                repeatMissionPenalty = 1.0f;
                break;
            case 1:
                repeatMissionPenalty = 0.7f;
                break;
            case 2:
                repeatMissionPenalty = 0.5f;
                break;
            case 3:
                repeatMissionPenalty = 0.3f;
                break;
            default:
                repeatMissionPenalty = 0.1f;
                break;
        }

        return repeatMissionPenalty;
    }

    public void DisplayCompanyStats()
    {
        //Debug.Log("failureProb: " + CalculateFailureProbability());
        //Debug.Log("task ratio: " + CheckTaskCompleted());
        //Debug.Log("rep: " + idealReputation + " and exp: " + idealExperience + " and money: " + idealMoney);

        CalculateReputation();
        CalculateExperience();
        MoneyGained();

        reputationText.text = "Overall Reputation: " + reputationScore_Mission;
        experienceText.text = "Overall Experience: " + experienceScore_Mission;
        moneyText.text = "Money: " + money_Mission;
    }

    public void BackToHome()
    {
        // Save Character Stats gained
        string[] charGeneralName = { "Manager", "Team Member 1", "Team Member 2", "Team Member 3", "Team Member 4" };
        foreach (string character in charGeneralName)
        {
            GameObject.Find("Canvas").transform.Find("Character Info Panel").GetComponent<ConfirmedCharacterInfoList>().SaveCharacterInfo(character);
        }
        //Debug.Log("Character stats saved.");

        // Save Product Stats gained
        this.GetComponent<UpdateProductStats>().SaveProductStats();
        
        // Save Company Stats gained
        this.GetComponent<UpdateCompanyStats>().SaveCompanyStats();
        //Debug.Log("Company Stats gained are saved.");

        SceneManager.LoadScene("In_Game_Home");
    }

    public void Time_Zero()
    {
        Time.timeScale = 0f;
    }
}
