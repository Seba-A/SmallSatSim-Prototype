using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameManager_Home : MonoBehaviour
{
    public GameObject OverallExperience;
    public GameObject OverallReputation;

    public int OverallExperienceScore;
    public int OverallReputationScore;

    private int repeatMissionCount = 0;
    private int repeatMissionPenalty = 1;

    private int reputationScore_Mission1;

    // Start is called before the first frame update
    void Start()
    {
        OverallExperienceScore = 0;
        OverallReputationScore = 0;

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
    }

    public void AddToOverallReputation()
    {
        if (repeatMissionCount == 0)
        {
            repeatMissionPenalty = 1;
        }


        OverallReputationScore += reputationScore_Mission1 * repeatMissionPenalty;
    }

    public void AddToOverallExperience()
    {

    }
    public void MoneyGained()
    {

    }
}
