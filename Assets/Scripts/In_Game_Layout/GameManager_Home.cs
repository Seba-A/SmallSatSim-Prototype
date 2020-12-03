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
    public float OverallMoney;

    private int repeatMissionCount = 0;
    private float repeatMissionPenalty = 1.0f;

    public TextMeshProUGUI confirmMissionText;
    public string lastMissionSelected;

    // PlayerPrefs Keys
    private readonly string countLoadsToHome = "NumberOfLoadsToHomeScene";
    public readonly string lastMissionPlayed = "LastMissionPlayed";

    private readonly string[] companyStatsName = { "reputation", "experience", "money" };
    private readonly string companyStats = "_companyStats_";

    // Start is called before the first frame update
    void Start()
    {
        OverallExperienceScore = 0;
        OverallReputationScore = 0;
        Debug.Log("number of times Home Scene is accessed: " + PlayerPrefs.GetInt(countLoadsToHome));

        if (PlayerPrefs.GetInt(countLoadsToHome) == 1 && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("In_Game_Home"))
        {
            GameObject.Find("Canvas").transform.Find("Character Info Panel").GetComponent<ConfirmedCharacterInfoList>().ResetCharacterInfo();
            Debug.Log("All character stats saved are reset.");
        }

        UpdateTheScore();

        if (PlayerPrefs.GetInt(countLoadsToHome) > 1)
        {
            AddToOverallReputation(PlayerPrefs.GetString(lastMissionPlayed));
            AddToOverallExperience(PlayerPrefs.GetString(lastMissionPlayed));
            MoneyGained(PlayerPrefs.GetString(lastMissionPlayed));
        }
    }

    //timer
    public void Update()
    {
        UpdateTheScore();

    }

    //set the score of each progress bar to 0 at the satr of the game
    private void UpdateTheScore()
    {
        OverallExperience.GetComponent<ProgressBar>().current = OverallExperienceScore;
        OverallReputation.GetComponent<ProgressBar>().current = OverallReputationScore;
    }

    public void DisplaySelectedMission(string missionSelected)
    {
        confirmMissionText.text = "Confirm " + missionSelected + "?";
    }

    public void AddToOverallReputation(string missionSceneName)
    {
        int reputationScore_Mission1 = PlayerPrefs.GetInt(missionSceneName + companyStats + "reputation");
        //Debug.Log(reputationScore_Mission1);
        OverallReputationScore += (int)(reputationScore_Mission1 * GetMissionPenalty(repeatMissionCount));
    }

    public void AddToOverallExperience(string missionSceneName)
    {
        int experienceScore_Mission1 = PlayerPrefs.GetInt(missionSceneName + companyStats + "experience");
        //Debug.Log(experienceScore_Mission1);
        OverallExperienceScore += (int)(experienceScore_Mission1 * GetMissionPenalty(repeatMissionCount));
    }

    public void MoneyGained(string missionSceneName)
    {
        float money_Mission1 = PlayerPrefs.GetFloat(missionSceneName + companyStats + "money");
        //Debug.Log(money_Mission1);
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

    public void LoadMission()
    {
        string[] charGeneralName = { "Manager", "Team Member 1", "Team Member 2", "Team Member 3", "Team Member 4" };
        foreach (string character in charGeneralName)
        {
            GameObject.Find("Canvas").transform.Find("Character Info Panel").GetComponent<ConfirmedCharacterInfoList>().SaveCharacterInfo(character);
        }
        //Debug.Log("Character stats saved.");

        SceneManager.LoadScene(lastMissionSelected);
    }
}


