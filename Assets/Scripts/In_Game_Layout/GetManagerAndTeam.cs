﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetManagerAndTeam : MonoBehaviour
{
    public GameObject managerAndTeam;

    public GameObject myManager;
    public GameObject[] managerList;
    public GameObject confirmedManager;

    public string selfRotateScript;

    public List<GameObject> myTeam;
    public GameObject myTeamInfo;
    public GameObject[] teamMemberList;
    public List<GameObject> confirmedTeam;

    private readonly string selectedManager = "SelectedManager";
    private readonly string[] selectedMembers = new string[4];

    // Start is called before the first frame update
    void Start()
    {
        // defining Keys for storing team members' name
        selectedMembers[0] = "SelectedMember1";
        selectedMembers[1] = "SelectedMember2";
        selectedMembers[2] = "SelectedMember3";
        selectedMembers[3] = "SelectedMember4";

        confirmedManager = myManager.GetComponent<GameObject>();
        //Debug.Log("Import keys and get manager to be game object component.");

        //managerAndTeam.SetActive(true);
        Debug.Log("show Manager and Team");

        GetMyManager();
        GetMyTeamInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetMyManager()
    {
        int managerInt = PlayerPrefs.GetInt(selectedManager);

        confirmedManager = Instantiate(managerList[managerInt], myManager.transform.position, myManager.transform.rotation);
        Debug.Log("The confirmed manager is: " + confirmedManager.name);

        confirmedManager.transform.SetParent(myManager.transform);
        confirmedManager.GetComponent<BoxCollider>().isTrigger = true;

        (confirmedManager.GetComponent(selfRotateScript) as MonoBehaviour).enabled = false;
    }

    public void GetMyTeamInfo()
    {
        // NOTE: Team member info is in the form of UI. Not 3D-objects!

        string[] teamString = new string[4];
        int[] confirmTeamInt = new int[4] { 0, 0, 0, 0 };

        for (int i = 0; i < myTeam.Count; i++)
        {
            teamString[i] = PlayerPrefs.GetString(selectedMembers[i]);
            Debug.Log(teamString[i]);

            foreach (GameObject element in teamMemberList)
            {
                if (element.name == teamString[i])
                {
                    confirmTeamInt[i] = System.Array.IndexOf(teamMemberList, element);
                    Debug.Log(confirmTeamInt);
                }
            }

            confirmedTeam[i] = Instantiate(teamMemberList[confirmTeamInt[i]], myTeamInfo.transform.position, myTeamInfo.transform.rotation);
            Debug.Log("Member " + i + " of name " + confirmedTeam[i].name + " is now added to the team.");

            confirmedTeam[i].transform.SetParent(myTeamInfo.transform);
            confirmedTeam[i].gameObject.SetActive(false);
        }
    }
}
