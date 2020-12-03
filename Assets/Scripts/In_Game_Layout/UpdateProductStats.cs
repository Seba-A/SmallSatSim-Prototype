using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpdateProductStats : MonoBehaviour
{ 
    private readonly string[] productName = { "redundancy", "reliability", "clarity", "efficiency", "innovation" };
    private readonly string productStats = "_productStats_";

    public int[] missionProductStats = new int[5];

    public void SaveProductStats()
    {
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + productStats + "redundancy", this.GetComponent<GameManager>().redundancyScore);
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + productStats + "reliability", this.GetComponent<GameManager>().reliabilityScore);
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + productStats + "clarity", this.GetComponent<GameManager>().clarityScore);
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + productStats + "efficiency", this.GetComponent<GameManager>().efficiencyScore);
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + productStats + "innovation", this.GetComponent<GameManager>().innovationScore);
    }

    public void UpdateProductStatsToHome(string missionSceneName)
    {
        missionProductStats[0] = PlayerPrefs.GetInt(missionSceneName + productStats + "redundancy");
        missionProductStats[1] = PlayerPrefs.GetInt(missionSceneName + productStats + "reliability");
        missionProductStats[2] = PlayerPrefs.GetInt(missionSceneName + productStats + "clarity");
        missionProductStats[3] = PlayerPrefs.GetInt(missionSceneName + productStats + "efficiency");
        missionProductStats[4] = PlayerPrefs.GetInt(missionSceneName + productStats + "innovation");
    }

    public void ResetProductStats()
    {
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + productStats + "redundancy", 0);
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + productStats + "reliability", 0);
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + productStats + "clarity", 0);
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + productStats + "efficiency", 0);
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + productStats + "innovation", 0);
    }
}
