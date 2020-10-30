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
    public List<GameObject> teamMembersList;
    public List<GameObject> memberPlaceholders;
    private List<GameObject> randomTeamMember;

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

        randomTeamMember = this.GetComponent<List<GameObject>>();     // there is a plural for getting component(s) for an array        

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
        //Debug.Log(randomTeamIndex[0]);

        for (int i = 0; i < 4; i++)
        {
            int randomTeamIndex = Random.Range(0, teamMembersList.Count - 1);
            randomTeamMember[i] = Instantiate(teamMembersList[randomTeamIndex], memberPlaceholders[i].transform.position, memberPlaceholders[i].transform.rotation);

            randomTeamMember[i].transform.parent = memberPlaceholders[i].transform;
        }
        Debug.Log(randomTeamMember);

        UpdateShuffleTries();
    }

    public void UpdateShuffleTries()
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
