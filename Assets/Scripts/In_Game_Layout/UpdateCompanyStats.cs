using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpdateCompanyStats : MonoBehaviour
{
    private readonly string[] companyStatsName = { "reputation", "experience", "money" };
    private readonly string companyStats = "_companyStats_";

    public void SaveCompanyStats()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + companyStats + "reputation", this.GetComponent<GameManager>().reputationScore_Mission1);
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + companyStats + "experience", this.GetComponent<GameManager>().experienceScore_Mission1);
        PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + companyStats + "money", this.GetComponent<GameManager>().money_Mission1);
    }

    public void ResetCompanyStats()
    {
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + companyStats + "reputation", 0);
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + companyStats + "experience", 0);
        PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + companyStats + "money", 0.0f);
    }
}
