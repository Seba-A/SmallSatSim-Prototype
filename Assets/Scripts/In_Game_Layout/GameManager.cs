using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject OverallExperience;
    public GameObject OverallReputation;

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

    public GameObject completeLevelUI;

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
        OverallExperience.GetComponent<ProgressBar>().current = OverallReputationScore;
        OverallReputation.GetComponent<ProgressBar>().current = OverallReputationScore;

        redundancy.GetComponent<ProgressBar>().current = redundancyScore;
        reliability.GetComponent<ProgressBar>().current = reliabilityScore;
        clarity.GetComponent<ProgressBar>().current = clarityScore;
        efficiency.GetComponent<ProgressBar>().current = efficiencyScore;
        innovation.GetComponent<ProgressBar>().current = innovationScore;
        progressbar.GetComponent<ProgressBar>().current = progressbarScore;
    }

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }
    public void NotCompleteLevel()
    {
        completeLevelUI.SetActive(false);
    }

    public void AddTOOverallReputation()
    {

    }
    public void AddTOOverallExperience()
    {

    }
    public void MoneyGained()
    {

    }
}
