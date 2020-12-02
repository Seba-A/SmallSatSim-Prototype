using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GetManagerAndTeam : MonoBehaviour
{
    public GameObject charInfoPanel;

    public GameObject myManager;                // placeholder for position in Scene
    public GameObject confirmedManager;         // selected manager that will be instantiated
    public CharacterInfo confirmedManagerInfo;  // stores the confirmed scriptable object (manager)

    public List<GameObject> myTeam;             // placeholder 3D-objects in the Scene
    public GameObject myTeamStats;              // placeholder UI for position in Canvas Character Stats Panel
    public List<GameObject> confirmedTeam;      // selected team member that will be instantiated
    public CharacterInfo[] confirmedTeamInfo;   // stores the confirmed scriptable object (team members)

    public GameObject[] managerList;            // full list of manager prefab
    public GameObject[] teamMemberList;         // full list of team member prefab

    private readonly string selectedManager = "SelectedManager";
    private readonly string[] selectedMembers = new string[4];

    // Start is called before the first frame update
    void Start()
    {
        // defining Keys for storing team members' name
        for (int i = 0; i < 4; i++)
        {
            selectedMembers[i] = "SelectedMember" + (i + 1).ToString();
        }

        charInfoPanel = GameObject.Find("Canvas").transform.Find("Character Info Panel").gameObject;
        myTeamStats = charInfoPanel.transform.Find("CharStats Panel").gameObject;

        GetMyManager();
        GetMyTeam();
        //Debug.Log("Selected manager and team members successfully imported to " + SceneManager.GetActiveScene().name);

        GetCharacterInfo();
    }

    private void Awake()
    {
        
    }

    private void GetMyManager()
    {
        int managerInt = PlayerPrefs.GetInt(selectedManager);

        confirmedManager = Instantiate(managerList[managerInt], myManager.transform.position, myManager.transform.rotation);
        confirmedManager.name = confirmedManager.name.Substring(0, confirmedManager.name.Length - 7);
        //Debug.Log("The confirmed manager is: " + confirmedManager.name);

        confirmedManager.transform.SetParent(myManager.transform);

        // configuring imported manager object to have the same settings as other team members
        confirmedManager.GetComponent<BoxCollider>().isTrigger = true;
        confirmedManager.tag = "Teammate";

        // remove SelfRotate script attached to manager prefab
        Destroy(confirmedManager.GetComponent<SelfRotate>());

        // add clickingonteam script to manager prefab
        confirmedManager.AddComponent<ClickingOnTeam>();
    }

    private void GetMyTeam()
    {
        // NOTE: Team member info is in the form of UI. Not 3D-objects!

        string[] teamString = new string[4];
        int[] confirmTeamInt = new int[4] { 0, 0, 0, 0 };

        for (int i = 0; i < myTeam.Count; i++)
        {
            teamString[i] = PlayerPrefs.GetString(selectedMembers[i]);
            //Debug.Log(teamString[i]);

            foreach (GameObject element in teamMemberList)
            {
                if (element.name == teamString[i])
                {
                    confirmTeamInt[i] = System.Array.IndexOf(teamMemberList, element);
                    //Debug.Log(confirmTeamInt);
                }
            }

            confirmedTeam[i] = teamMemberList[confirmTeamInt[i]];
            confirmedTeam[i].name = confirmedTeam[i].name.Substring(0, confirmedTeam[i].name.Length - 7);
            //Debug.Log("Member " + i + " of name " + confirmedTeam[i].name + " is now added to the team.");
        }
    }

    public void GetCharacterInfo()
    {
        // Get Manager Info
        int managerInt = PlayerPrefs.GetInt(selectedManager);
        confirmedManagerInfo = charInfoPanel.GetComponent<ConfirmedCharacterInfoList>().managerInfoList[managerInt];
        charInfoPanel.GetComponent<ConfirmedCharacterInfoList>().managerInfo = confirmedManagerInfo;

        // Get Team Info
        string[] teamString = new string[4];

        for (int i = 0; i < selectedMembers.Length; i++)
        {
            //Debug.Log(selectedMembers[i]);
            teamString[i] = PlayerPrefs.GetString(selectedMembers[i]);
            //Debug.Log(teamString[i]);

            foreach (CharacterInfo element in charInfoPanel.GetComponent<ConfirmedCharacterInfoList>().teamInfoList)
            {
                //Debug.Log(element.ToString().Substring(0, 7));
                if (element.ToString().Substring(0, 7) == teamString[i].Substring(0, 7))
                {
                    // Appending element to array: https://answers.unity.com/questions/1033253/c-how-to-append-to-an-array.html

                    Array.Resize(ref confirmedTeamInfo, confirmedTeamInfo.Length + 1);
                    confirmedTeamInfo[confirmedTeamInfo.Length - 1] = element;

                    Array.Resize(ref charInfoPanel.GetComponent<ConfirmedCharacterInfoList>().teamMemberInfo, charInfoPanel.GetComponent<ConfirmedCharacterInfoList>().teamMemberInfo.Length + 1);
                    charInfoPanel.GetComponent<ConfirmedCharacterInfoList>().teamMemberInfo[charInfoPanel.GetComponent<ConfirmedCharacterInfoList>().teamMemberInfo.Length - 1] = element;
                }
            }
        }
    }
}

