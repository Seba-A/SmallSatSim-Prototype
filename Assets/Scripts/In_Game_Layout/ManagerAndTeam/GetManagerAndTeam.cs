using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetManagerAndTeam : MonoBehaviour
{
    public GameObject myManager;            // placeholder for position in Scene
    public GameObject[] managerList;        // full list of manager prefab
    public GameObject confirmedManager;     // selected manager that will be instantiated

    public List<GameObject> myTeam;         // placeholder 3D-objects in the Scene
    public GameObject myTeamInfo;           // placeholder UI for position in Canvas Character Info Panel
    public GameObject[] teamMemberList;     // full list of team member prefab
    public List<GameObject> confirmedTeam;  // selected team member that will be instantiated

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

        GetMyManager();
        GetMyTeamInfo();

        Debug.Log("Selected manager and team members successfully imported to " + SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetMyManager()
    {
        int managerInt = PlayerPrefs.GetInt(selectedManager);

        confirmedManager = Instantiate(managerList[managerInt], myManager.transform.position, myManager.transform.rotation);
        confirmedManager.name = confirmedManager.name.Substring(0, confirmedManager.name.Length - 7);
        Debug.Log("The confirmed manager is: " + confirmedManager.name);

        confirmedManager.transform.SetParent(myManager.transform);

        // configuring imported manager object to have the same settings as other team members
        confirmedManager.GetComponent<BoxCollider>().isTrigger = true;
        confirmedManager.tag = "Teammate";

        // remove SelfRotate script attached to manager prefab
        Destroy(confirmedManager.GetComponent<SelfRotate>());

        // add clickingonteam script to manager prefab
        confirmedManager.AddComponent<ClickingOnTeam>();
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
                    //Debug.Log(confirmTeamInt);
                }
            }

            confirmedTeam[i] = Instantiate(teamMemberList[confirmTeamInt[i]], myTeamInfo.transform.position, myTeamInfo.transform.rotation);
            confirmedTeam[i].name = confirmedTeam[i].name.Substring(0, confirmedTeam[i].name.Length - 7);
            Debug.Log("Member " + i + " of name " + confirmedTeam[i].name + " is now added to the team.");

            confirmedTeam[i].transform.SetParent(myTeamInfo.transform);
            confirmedTeam[i].gameObject.SetActive(false);

            // remove the Select Button game object on each member
            Destroy(confirmedTeam[i].transform.Find("Select Button").gameObject);
        }
    }
}
