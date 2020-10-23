﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TeamChacManager : MonoBehaviour
{
    public Button confirmTeamButton;
    public Button shuffleButton;

    public TextMeshProUGUI shuffleTriesText;
    private int shuffleTries = 4;

    private int[] teamIndex = new int[3];

    // Start is called before the first frame update
    void Start()
    {
        confirmTeamButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (shuffleTries < 4)
        {
            confirmTeamButton.gameObject.SetActive(true);
        }
        if (shuffleTries == 0)
        {
            shuffleButton.gameObject.SetActive(false);
        }

    }

    public void RandomTeamShuffle()
    {
        /*foreach (int element in teamIndex)
        { 
            element = Random.Range(1, 30);
        }
        */

        UpdateShuffleTries();
    }

    public void UpdateShuffleTries()
    {
        shuffleTries--;
        shuffleTriesText.text = "Tries Left: " + shuffleTries;

        Debug.Log("Times left to reshuffle team: " + shuffleTries);
    }

    public void ReSelectManager()
    {
        SceneManager.LoadScene("Manager_Character_Selection");
    }
}
