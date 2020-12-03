﻿using System;
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
    public float OverallMoney;

    private int repeatMissionCount = 0;
    private float repeatMissionPenalty = 1.0f;

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
        int reputationScore_Mission1 = 1;
        OverallReputationScore += (int)(reputationScore_Mission1 * GetMissionPenalty(repeatMissionCount));
    }

    public void AddToOverallExperience()
    {
        int experienceScore_Mission1 = 1;
        OverallExperienceScore += (int)(experienceScore_Mission1 * GetMissionPenalty(repeatMissionCount));
    }

    public void MoneyGained()
    {
        int money_Mission1 = 1;
        OverallMoney += (int)(money_Mission1 * GetMissionPenalty(repeatMissionCount));
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

    // improve to work for all missions
    public void Mission1()
    {
        GameObject.Find("Canvas").transform.Find("Character Info Panel").GetComponent<ConfirmedCharacterInfoList>().SaveCharacterInfo("Manager");
        Debug.Log("Character stats saved.");
        SceneManager.LoadScene("Mission 1");
    }
}

