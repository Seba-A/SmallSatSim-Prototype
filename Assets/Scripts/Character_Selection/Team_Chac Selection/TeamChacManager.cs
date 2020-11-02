using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TeamChacManager : MonoBehaviour
{
    public Button confirmTeamButton;
    public Button shuffleButton;

    // T_Chac/Panel_TeamStats Section
    public List<GameObject> teamMembersList;    // the whole list of team member character prefabs.
    public List<GameObject> memberPlaceholders; // empty gameobject acting as placeholders (& parent) for clone of TeamMember.
    public GameObject[] randomTeamMember;       // empty gameobject to be substituted as a clone of TeamMember.

    // Shuffling Button & Text Section
    public TextMeshProUGUI shuffleTriesText;
    private int shuffleTries = 4;

    // Team Member Key (to store player preferences)
    private readonly string[] selectedMembers = new string[4];
    public int selectionAttempts = 0;
    public int noOfMemberSelected = 0;

    // T_Chac/ChosenManager Section
    public GameObject[] managerAndTeam; //managerObjects, teamObjects, managerSelection, teamSelection, managerInstructions, teamInstructions;
    public GameObject selectedManager;


    // Start is called before the first frame update
    void Start()
    {
        confirmTeamButton.interactable = false;

        // defining Keys for storing team members' name
        selectedMembers[0] = "SelectedMember1";
        selectedMembers[1] = "SelectedMember2";
        selectedMembers[2] = "SelectedMember3";
        selectedMembers[3] = "SelectedMember4";
    }

    // Update is called once per frame
    void Update()
    {
        if (shuffleTries < 4)
        {
            confirmTeamButton.interactable = true;
        }

        if (shuffleTries == 0)
        {
            shuffleButton.gameObject.SetActive(false);
        }

        if (noOfMemberSelected == 4)
        {
            shuffleButton.interactable = false;
        }
        else
        {
            shuffleButton.interactable = true;
        }
    }


    #region T_Chac/Panel_TeamStats Section

    public void RandomTeamShuffle()
    {
        int[] previousRandomIndex = new int[4] { 999, 999, 999, 999 };
        int[] randomTeamIndex = new int[4] { 0, 0, 0, 0 };

        // max i range is 4 elements as there are 4 team member slots
        for (int i = 0; i < 4; i++)
        {
            // Delete all child objects
            foreach (Transform child in memberPlaceholders[i].transform)
            {
                Destroy(child.gameObject);
            }
            Debug.Log("Clear all child");

            // Create random member (without repeat) by comparing each element of previousRandomIndex
            for (int j = 0; j < 4; j++)
            {
                while (randomTeamIndex[i] == previousRandomIndex[j])
                {
                    randomTeamIndex[i] = Random.Range(0, teamMembersList.Count);
                    j = 0;      // if there is a need to re-generate a new randomTeamIndex, the counter j is re-set to zero.
                }
            }
            Debug.Log(randomTeamIndex[i]);

            previousRandomIndex[i] = randomTeamIndex[i];
            Debug.Log(previousRandomIndex[i]);

            // Clone the appropraite prefab (team member) based on the random index
            randomTeamMember[i] = Instantiate(teamMembersList[randomTeamIndex[i]], memberPlaceholders[i].transform.position, memberPlaceholders[i].transform.rotation);
            Debug.Log("a random team member is selected");

            // set the parent of the instantiated team member to be the empty gameobject
            randomTeamMember[i].transform.SetParent(memberPlaceholders[i].transform);
                //the not-so-efficient way: randomTeamMember[i].transform.parent = memberPlaceholders[i].transform;
        }
        
        UpdateShuffleTries();
    }

    private void UpdateShuffleTries()
    {
        shuffleTries--;
        shuffleTriesText.text = "Tries Left: " + shuffleTries;

        Debug.Log("Times left to reshuffle team: " + shuffleTries);
    }

    // Selecting Team Members and Saving Team Data
    public void SaveSelectedMember(string selectedObjName)
    {
        int memberIndex;

        if (selectionAttempts > 3)
        {
            memberIndex = selectionAttempts % 4;
        }
        else
        {
            memberIndex = selectionAttempts;
        }

        PlayerPrefs.SetString(selectedMembers[memberIndex], selectedObjName);
        Debug.Log(selectedObjName + " is saved to Key: " + selectedMembers[memberIndex] + " with member index: " + memberIndex);

        selectionAttempts++;
        Debug.Log("attempts: " + selectionAttempts);
    }

    #endregion


    #region T_Chac/ChosenManager Section

    public void ReSelectManager()
    {
        // switch back to manager selection
        managerAndTeam[0].SetActive(true);
        managerAndTeam[1].SetActive(false);
        managerAndTeam[2].SetActive(true);
        managerAndTeam[3].SetActive(false);
        managerAndTeam[4].SetActive(true);
        managerAndTeam[5].SetActive(false);
        Debug.Log("Now time to select your manager, again.");

        // Destroy previously imported Manager
        // Note: Relevant buttons and UI has been disabled in Unity GameObject's Inspector Window
        selectedManager.GetComponent<GetMainChac>().DeleteOldCharacter();
    }

    #endregion

}
