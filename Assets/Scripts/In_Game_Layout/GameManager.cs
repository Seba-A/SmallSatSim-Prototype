using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
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
        redundancyScore = 0;
        reliabilityScore = 0;
        clarityScore = 0;
        efficiencyScore = 0;
        innovationScore = 0;
        progressbarScore = 0;

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
        completeLevelUI.SetActive(true);
    }
}
