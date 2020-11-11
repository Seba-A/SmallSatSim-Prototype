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

    public int redundancyScore = 0;
    public int reliabilityScore = 0;
    public int clarityScore = 0;
    public int efficiencyScore = 0;
    public int innovationScore = 0;
    public int progressbarScore = 0;

    // Start is called before the first frame update
    void Start()
    {
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
}
