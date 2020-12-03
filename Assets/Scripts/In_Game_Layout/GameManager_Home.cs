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

    public GameObject missionSelectionPanel;
    private GameObject contentListOfMissions;

    public TextMeshProUGUI confirmMissionText;
    public string lastMissionSelected;

    // PlayerPrefs Keys
    private readonly string countLoadsToHome = "NumberOfLoadsToHomeScene";
    public readonly string lastMissionPlayed = "LastMissionPlayed";
    private readonly string repeatMissionCount = "NumberOfTimesMissionIsRepeated";

    private readonly string[] companyStatsName = { "reputation", "experience", "money" };
    private readonly string companyStats = "_companyStats_";

    private void Awake()
    {
        contentListOfMissions = missionSelectionPanel.transform.Find("Scroll Area").transform.GetChild(0).gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Resetting all saved data when loading into Home Scene the first time
        if (PlayerPrefs.GetInt(countLoadsToHome) == 1 && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("In_Game_Home"))
        {
            GameObject.Find("Canvas").transform.Find("Character Info Panel").GetComponent<ConfirmedCharacterInfoList>().ResetCharacterInfo();
            //Debug.Log("All character stats saved are reset.");

            foreach (Transform child in contentListOfMissions.transform)
            {
                PlayerPrefs.SetInt(child.name + repeatMissionCount, -1);
            }
            //Debug.Log("All mission count is reset.");

            this.GetComponent<UpdateCompanyStats>().ResetCompanyStats();
            //Debug.Log("All company stats are reset.");
        }

        OverallExperienceScore = PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + companyStats + "experience");
        OverallReputationScore = PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + companyStats + "reputation");
        OverallMoney = PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + companyStats + "money");
        //Debug.Log("number of times Home Scene is accessed: " + PlayerPrefs.GetInt(countLoadsToHome));

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
        OverallReputationScore += PlayerPrefs.GetInt(missionSceneName + companyStats + "reputation");
        //Debug.Log(OverallReputationScore);
    }

    public void AddToOverallExperience(string missionSceneName)
    {
        OverallExperienceScore += PlayerPrefs.GetInt(missionSceneName + companyStats + "experience");
        //Debug.Log(OverallExperienceScore);
    }

    public void MoneyGained(string missionSceneName)
    {
        OverallMoney += PlayerPrefs.GetFloat(missionSceneName + companyStats + "money");
        //Debug.Log(OverallMoney);
    }

    public void LoadMission()
    {
        // Saving Char Stats
        string[] charGeneralName = { "Manager", "Team Member 1", "Team Member 2", "Team Member 3", "Team Member 4" };
        foreach (string character in charGeneralName)
        {
            GameObject.Find("Canvas").transform.Find("Character Info Panel").GetComponent<ConfirmedCharacterInfoList>().SaveCharacterInfo(character);
        }
        //Debug.Log("Character stats saved.");

        // Saving Company Stats
        this.GetComponent<UpdateCompanyStats>().SaveCompanyStats_HomeScene();

        // Adding mission count
        foreach (Transform child in contentListOfMissions.transform)
        {
            if (child.name == lastMissionSelected)
            {
                //Debug.Log(child.name);
                child.GetComponent<MissionRepeatCounter>().IncreaseRepeatCount(lastMissionSelected);
            }
        }

        // Loading relevant mission scene
        SceneManager.LoadScene(lastMissionSelected);
    }
}


