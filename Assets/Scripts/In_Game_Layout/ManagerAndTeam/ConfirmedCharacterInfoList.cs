using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ConfirmedCharacterInfoList : MonoBehaviour
{
    public GameObject managerAndTeam;

    // confirmed manager and team
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

    public void GetCharacterInfo()
    {

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

    }
}
