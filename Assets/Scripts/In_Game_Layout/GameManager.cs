using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int OverallExperienceScore;
    public int OverallReputationScore;

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

    // Start is called before the first frame update
    void Start()
    {
        OverallExperienceScore = 0;
        OverallReputationScore = 0;

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

    /* How to define mission success:
     * 
     * Sum up Redundancy, Reliability, Clarity, Efficiency, Innovation  => OverallProductScore
     * 
     * Comparing player OverallProductScore to expected OverallProductScore for launch (benchmark = 75%):
     * 
     * diffScore = playerScore / expectedScore; 
     * 
     * if (diffScore > 1.2f)
     * then failureProbability = 5;
     * 
     * if (diffScore > 1.0f && diffScore <= 1.2f)
     * then failureProbability = 10;
     * 
     * if (diffScore > 0.8f && diffScore <= 1.0f)
     * then failureProbability = 20;
     * 
     * if (diffScore > 0.6f && diffScore <= 0.8f)
     * then failureProbability = 40;
     * 
     * if (diffScore > 0.4f && diffScore <= 0.6f)
     * then failureProbability = 60;
     * 
     * if (diffScore <= 0.4f)
     * then failureProbability = 85;
     * 
     *
     * int failureProbabilityScore = UnityEngine.Random.Range(1, 101);    //assuming that 0-100 have equally chances of being selected
     * 
     * if (failureProbabilityScore <= failureProbability)
     * then FAIL!;
     * 
     * 
     */

    public void CalculateReputation()
    {
        // total reputation that can be obtained from this mission
        int totalReputation = 100;
    }

    public void CalculateExperience()
    {

    }

    public void MoneyGained()
    {

    }
}
