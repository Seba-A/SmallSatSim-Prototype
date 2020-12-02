using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ConfirmedCharacterInfoList : MonoBehaviour
{
    public GameObject managerAndTeam;

    private readonly string selectedManager = "SelectedManager";
    private readonly string[] selectedMembers = new string[4];

    // confirmed manager and team
    public CharacterInfo managerInfo;
    public CharacterInfo[] teamMemberInfo;

    // full list of manager and team scriptable objects
    public CharacterInfo[] managerInfoList;
    public CharacterInfo[] teamInfoList;

    void Start()
    {
        // calling the same Keys that stores selected team members' name
        for (int i=0; i<4; i++)
        {
            selectedMembers[i] = "SelectedMember" + (i + 1).ToString();
        }


        GetCharacterInfo();

        /*  // Appending element to array: https://answers.unity.com/questions/1033253/c-how-to-append-to-an-array.html
        int size = 5;

        Array.Resize(ref teamMemberInfo, teamMemberInfo.Length + size);
        teamMemberInfo[teamMemberInfo.Length - size] = teamInfoList[0];
        teamMemberInfo[teamMemberInfo.Length - size + 1] = teamInfoList[1];

        Array.Resize(ref teamMemberInfo, teamMemberInfo.Length + 1);
        teamMemberInfo[teamMemberInfo.Length - size + 1] = teamInfoList[2];
        */
    }

    public void GetCharacterInfo()
    {
        // Get Manager Info
        int managerInt = PlayerPrefs.GetInt(selectedManager);
        managerInfo = managerInfoList[managerInt];

        // Get Team Info
        string[] teamString = new string[4];

        for (int i = 0; i < selectedMembers.Length; i++)
        {
            teamString[i] = PlayerPrefs.GetString(selectedMembers[i]);
            //Debug.Log(teamString[i]);

            foreach (CharacterInfo element in teamInfoList)
            {
                //Debug.Log(element.ToString().Substring(0, 7));
                if (element.ToString().Substring(0, 7) == teamString[i].Substring(0,7))
                {
                    Array.Resize(ref teamMemberInfo, teamMemberInfo.Length + 1);
                    teamMemberInfo[teamMemberInfo.Length - 1] = element;
                }
            }
        }
    }

    public void UpdateCharacterInfo()
    {
        

    }
}
