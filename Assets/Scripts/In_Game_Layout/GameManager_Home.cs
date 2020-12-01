using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager_Home : MonoBehaviour
{
    public GameObject OverallExperience;
    public GameObject OverallReputation;

    public int OverallExperienceScore;
    public int OverallReputationScore;

    private int repeatMissionCount = 0;
    private float repeatMissionPenalty = 1.0f;

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
        switch (repeatMissionCount)
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

        OverallReputationScore += (int)(reputationScore_Mission1 * repeatMissionPenalty);
    }

    public void AddToOverallExperience()
    {

    }
    public void MoneyGained()
    {

    }

    public void Mission1()
    {
        SceneManager.LoadScene("Mission 1");
    }
}
