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
    public int idealOverallProductScore = 75;
    private float failureProbability;

    // Start is called before the first frame update
    void Start()
    {
        reputationScore_Mission1 = 0;
        experienceScore_Mission1 = 0;

        //this value will need to be set to 0 when the mission panel is made active no in the gamemanager
        //Added a new script "SetMissionScore" to do so, this is attached to the Mission 1 panel
        /*
        redundancyScore = 0;
        reliabilityScore = 0;
        clarityScore = 0;
        efficiencyScore = 0;
        innovationScore = 0;
        progressbarScore = 0;*/

        UpdateTheScore();
    }

    //timer
    public void Update()
    {
        UpdateTheScore();
    }

    //set the score of each progress bar to 0 at the satr of the game
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

    public void CalculateFailureProbability()
    {
        overallProductScore = redundancyScore + reliabilityScore + clarityScore + efficiencyScore + innovationScore;

        float diffScore = overallProductScore / idealOverallProductScore;

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

    public void CheckTaskCompleted()
    {

    }

    public void CalculateReputation()
    {
        reputationScore_Mission1 = (int)(idealReputation * (1 - (failureProbability/100)));
    }

    public void CalculateExperience()
    {
        experienceScore_Mission1 = (int)(idealExperience * (1 - (failureProbability / 100)));
    }

    public void MoneyGained()
    {
        money_Mission1 = idealMoney * (1 - (failureProbability / 100));
    }

    public void BackToHome()
    {
        SceneManager.LoadScene("In_Game_Home");
    }
}
