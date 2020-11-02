using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetManagerAndTeam : MonoBehaviour
{
    public GameObject myManager;
    public GameObject[] managerList;
    public GameObject confirmedManager;

    public List<GameObject> myTeam;
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

        GetMyManager();
        GetMyTeam();

        /*
        SceneManager.MoveGameObjectToScene(myManager, SceneManager.GetActiveScene());
        foreach (GameObject member in myTeam)
        {
            SceneManager.MoveGameObjectToScene(member, SceneManager.GetActiveScene());
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetMyManager()
    {
        int managerInt = PlayerPrefs.GetInt(selectedManager);

        confirmedManager = Instantiate(managerList[managerInt], myManager.transform.position, myManager.transform.rotation);

        confirmedManager.transform.parent = myManager.transform;
    }

    public void GetMyTeam()
    {
        string[] teamString = new string[4];
        for (int i = 0; i < myTeam.Count; i++)
        {
            teamString[i] = PlayerPrefs.GetString(selectedMembers[i]);
            confirmedTeam[i] = GameObject.Find(teamString[i]);

            confirmedTeam[i].transform.parent = myTeam[i].transform;
        }
    }
}
