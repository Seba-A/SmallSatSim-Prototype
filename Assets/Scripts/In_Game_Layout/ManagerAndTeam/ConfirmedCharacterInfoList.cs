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
    private readonly string selectedManager = "SelectedManager";
    private readonly string[] selectedMembers = new string[4] { "SelectedMember1", "SelectedMember2", "SelectedMember3", "SelectedMember4" };

    // PlayerPref Keys for Character Info
    private readonly string charInfo = "_info_";

    // PlayerPref Keys for Character Roles
    private readonly string primaryRole = " PrimaryRoleOption";
    private readonly string secondaryRole = " SecondaryRoleOption";

    public void GetCharacterInfo(string charName)
    {
        CharacterInfo charToGet = null;

        switch (charName)
        {
            case "Manager":
                charToGet = managerAndTeam.GetComponent<GetManagerAndTeam>().confirmedManagerInfo;
                break;
            case "Team Member 1":
                charToGet = managerAndTeam.GetComponent<GetManagerAndTeam>().confirmedTeamInfo[0];
                break;
            case "Team Member 2":
                charToGet = managerAndTeam.GetComponent<GetManagerAndTeam>().confirmedTeamInfo[1];
                break;
            case "Team Member 3":
                charToGet = managerAndTeam.GetComponent<GetManagerAndTeam>().confirmedTeamInfo[2];
                break;
            case "Team Member 4":
                charToGet = managerAndTeam.GetComponent<GetManagerAndTeam>().confirmedTeamInfo[3];
                break;
        }

        charToGet.speed = PlayerPrefs.GetInt(charName + charInfo + "speed");
        charToGet.quality = PlayerPrefs.GetInt(charName + charInfo + "quality");
        charToGet.relationship = PlayerPrefs.GetInt(charName + charInfo + "relationship");
        charToGet.focus = PlayerPrefs.GetInt(charName + charInfo + "focus");
        charToGet.creativity = PlayerPrefs.GetInt(charName + charInfo + "creativity");

        charToGet.trait = PlayerPrefs.GetString(charName + charInfo + "trait");
        charToGet.field = PlayerPrefs.GetString(charName + charInfo + "field");

        switch (charName)
        {
            case "Manager":
                managerInfo = charToGet;
                break;
            case "Team Member 1":
                teamMemberInfo[0] = charToGet;
                break;
            case "Team Member 2":
                teamMemberInfo[1] = charToGet;
                break;
            case "Team Member 3":
                teamMemberInfo[2] = charToGet;
                break;
            case "Team Member 4":
                teamMemberInfo[3] = charToGet;
                break;
        }
    }

    public void UpdateCharacterInfo(string charName)
    {
        CharacterInfo charToUpdate = null;

        switch (charName)
        {
            case "Manager":
                charToUpdate = managerInfo;
                break;
            case "Team Member 1":
                charToUpdate = teamMemberInfo[0];
                break;
            case "Team Member 2":
                charToUpdate = teamMemberInfo[1];
                break;
            case "Team Member 3":
                charToUpdate = teamMemberInfo[2];
                break;
            case "Team Member 4":
                charToUpdate = teamMemberInfo[3];
                break;
        }

        PlayerPrefs.SetInt(charName + charInfo + "speed", charToUpdate.speed);
        PlayerPrefs.SetInt(charName + charInfo + "quality", charToUpdate.quality);
        PlayerPrefs.SetInt(charName + charInfo + "relationship", charToUpdate.relationship);
        PlayerPrefs.SetInt(charName + charInfo + "focus", charToUpdate.focus);
        PlayerPrefs.SetInt(charName + charInfo + "creativity", charToUpdate.creativity);

        PlayerPrefs.SetString(charName + charInfo + "trait", charToUpdate.trait);
        PlayerPrefs.SetString(charName + charInfo + "field", charToUpdate.field);

        switch (charName)
        {
            case "Manager":
                managerAndTeam.GetComponent<GetManagerAndTeam>().confirmedManagerInfo = charToUpdate;
                break;
            case "Team Member 1":
                managerAndTeam.GetComponent<GetManagerAndTeam>().confirmedTeamInfo[0] = charToUpdate;
                break;
            case "Team Member 2":
                managerAndTeam.GetComponent<GetManagerAndTeam>().confirmedTeamInfo[1] = charToUpdate;
                break;
            case "Team Member 3":
                managerAndTeam.GetComponent<GetManagerAndTeam>().confirmedTeamInfo[2] = charToUpdate;
                break;
            case "Team Member 4":
                managerAndTeam.GetComponent<GetManagerAndTeam>().confirmedTeamInfo[3] = charToUpdate;
                break;
        }
    }
}
