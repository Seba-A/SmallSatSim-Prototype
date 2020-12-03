using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ConfirmedCharacterInfoList : MonoBehaviour
{
    public GameObject managerAndTeam;

    /* Confirmed manager and team
     * All changes to the character stats within a Mission Scene will be targeted to changing these variables.
     */
    public CharacterInfo managerInfo;
    public CharacterInfo[] teamMemberInfo;

    // full list of manager and team scriptable objects
    public CharacterInfo[] managerInfoList;
    public CharacterInfo[] teamInfoList;

    // PlayerPref Keys for Manager and Team Gameobjects
    //private readonly string selectedManager = "SelectedManager";
    //private readonly string[] selectedMembers = new string[4] { "SelectedMember1", "SelectedMember2", "SelectedMember3", "SelectedMember4" };

    // PlayerPref Keys for Character Info
    private readonly string[] charGeneralName = { "Manager", "Team Member 1", "Team Member 2", "Team Member 3", "Team Member 4" };
    private readonly string charInfo = "_info_";

    // PlayerPref Keys for Character Roles
    //private readonly string primaryRole = " PrimaryRoleOption";
    //private readonly string secondaryRole = " SecondaryRoleOption";

    public void LoadCharacterInfo(string charName)
    {
        CharacterInfo charToLoad = null;

        // Taking start game data from CharInfoPanel
        switch (charName)
        {
            case "Manager":
                charToLoad = managerInfo;
                break;
            case "Team Member 1":
                charToLoad = teamMemberInfo[0];
                break;
            case "Team Member 2":
                charToLoad = teamMemberInfo[1];
                break;
            case "Team Member 3":
                charToLoad = teamMemberInfo[2];
                break;
            case "Team Member 4":
                charToLoad = teamMemberInfo[3];
                break;
        }

        // Loading Data from PlayerPrefs
        charToLoad.speed = PlayerPrefs.GetInt(charName + charInfo + "speed");
        charToLoad.quality = PlayerPrefs.GetInt(charName + charInfo + "quality");
        charToLoad.relationship = PlayerPrefs.GetInt(charName + charInfo + "relationship");
        charToLoad.focus = PlayerPrefs.GetInt(charName + charInfo + "focus");
        charToLoad.creativity = PlayerPrefs.GetInt(charName + charInfo + "creativity");

        charToLoad.trait = PlayerPrefs.GetString(charName + charInfo + "trait");
        charToLoad.field = PlayerPrefs.GetString(charName + charInfo + "field");

        // Updating loaded data to relevant character -- in both CharInfoPanel and ManagerAndTeam
        switch (charName)
        {
            case "Manager":
                managerInfo = charToLoad;
                managerAndTeam.GetComponent<GetManagerAndTeam>().confirmedManagerInfo = charToLoad;
                break;
            case "Team Member 1":
                teamMemberInfo[0] = charToLoad;
                managerAndTeam.GetComponent<GetManagerAndTeam>().confirmedTeamInfo[0] = charToLoad;
                break;
            case "Team Member 2":
                teamMemberInfo[1] = charToLoad;
                managerAndTeam.GetComponent<GetManagerAndTeam>().confirmedTeamInfo[1] = charToLoad;
                break;
            case "Team Member 3":
                teamMemberInfo[2] = charToLoad;
                managerAndTeam.GetComponent<GetManagerAndTeam>().confirmedTeamInfo[2] = charToLoad;
                break;
            case "Team Member 4":
                teamMemberInfo[3] = charToLoad;
                managerAndTeam.GetComponent<GetManagerAndTeam>().confirmedTeamInfo[3] = charToLoad;
                break;
        }
    }

    public void SaveCharacterInfo(string charName)
    {
        CharacterInfo charToSave = null;

        // Taking most recent data from CharInfoPanel
        switch (charName)
        {
            case "Manager":
                charToSave = managerInfo;
                break;
            case "Team Member 1":
                charToSave = teamMemberInfo[0];
                break;
            case "Team Member 2":
                charToSave = teamMemberInfo[1];
                break;
            case "Team Member 3":
                charToSave = teamMemberInfo[2];
                break;
            case "Team Member 4":
                charToSave = teamMemberInfo[3];
                break;
        }

        // Saving Data to PlayerPrefs
        PlayerPrefs.SetInt(charName + charInfo + "speed", charToSave.speed);
        PlayerPrefs.SetInt(charName + charInfo + "quality", charToSave.quality);
        PlayerPrefs.SetInt(charName + charInfo + "relationship", charToSave.relationship);
        PlayerPrefs.SetInt(charName + charInfo + "focus", charToSave.focus);
        PlayerPrefs.SetInt(charName + charInfo + "creativity", charToSave.creativity);

        PlayerPrefs.SetString(charName + charInfo + "trait", charToSave.trait);
        PlayerPrefs.SetString(charName + charInfo + "field", charToSave.field);

        // Updating relevant character in ManagerAndTeam to most recent data
        switch (charName)
        {
            case "Manager":
                managerAndTeam.GetComponent<GetManagerAndTeam>().confirmedManagerInfo = charToSave;
                break;
            case "Team Member 1":
                managerAndTeam.GetComponent<GetManagerAndTeam>().confirmedTeamInfo[0] = charToSave;
                break;
            case "Team Member 2":
                managerAndTeam.GetComponent<GetManagerAndTeam>().confirmedTeamInfo[1] = charToSave;
                break;
            case "Team Member 3":
                managerAndTeam.GetComponent<GetManagerAndTeam>().confirmedTeamInfo[2] = charToSave;
                break;
            case "Team Member 4":
                managerAndTeam.GetComponent<GetManagerAndTeam>().confirmedTeamInfo[3] = charToSave;
                break;
        }
    }

    public void ResetCharacterInfo()
    {
        // Resetting Data saved in PlayerPrefs
        foreach (string character in charGeneralName)
        {
            PlayerPrefs.SetInt(character + charInfo + "speed", 0);
            PlayerPrefs.SetInt(character + charInfo + "quality", 0);
            PlayerPrefs.SetInt(character + charInfo + "relationship", 0);
            PlayerPrefs.SetInt(character + charInfo + "focus", 0);
            PlayerPrefs.SetInt(character + charInfo + "creativity", 0);

            PlayerPrefs.SetString(character + charInfo + "trait", "null");
            PlayerPrefs.SetString(character + charInfo + "field", "null");
        }
    }
}
