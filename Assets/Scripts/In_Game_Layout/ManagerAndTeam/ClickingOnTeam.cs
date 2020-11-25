using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickingOnTeam : MonoBehaviour
{
    RaycastHit hitInfo;
    //Vector2 currentPos;

    [SerializeField] private GameObject charInfoPanel;
    [SerializeField] private GameObject charStats;
    [SerializeField] private GameObject charRolesNTasks;

    private GameObject managerAndTeam;

    private readonly string selectedManager = "SelectedManager";
    private readonly string[] selectedMembers = new string[4];

    // variables needed for double-clicking
    private float clicked = 0;
    private float clicktime = 0;
    private float clickdelay = 0.5f;

    void Start()
    {
        charInfoPanel = GameObject.Find("Canvas").transform.Find("Character Info Panel").gameObject;
        charStats = charInfoPanel.transform.Find("CharStats Panel").gameObject;
        charRolesNTasks = charInfoPanel.transform.Find("Roles & Tasks Placeholder").gameObject;

        //currentPos = charInfoPanel.GetComponent<RectTransform>().position;

        // defining Keys used for storing team members' name
        selectedMembers[0] = "SelectedMember1";
        selectedMembers[1] = "SelectedMember2";
        selectedMembers[2] = "SelectedMember3";
        selectedMembers[3] = "SelectedMember4";

        managerAndTeam = GameObject.Find("Manager And Team");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.gameObject.tag == "Teammate")
                {
                    clicked++;
                    //Debug.Log(clicked);

                    if (clicked == 1) clicktime = Time.time;

                    // double-click opens the character info panel
                    if (clicked > 1 && Time.time - clicktime < clickdelay)
                    {
                        Debug.Log("Double Clicked on: " + hitInfo.collider.gameObject.name);

                        clicked = 0;
                        clicktime = 0;

                        charInfoPanel.SetActive(true);
                        //currentPos.x = 0;
                        //charInfoPanel.transform.position = new Vector2(currentPos.x, currentPos.y);

                        CloseAllCharInfo();       //function added here to avoid more than one character info opening at the same time

                        OpenCorrectCharInfo();

                    }
                    else if (clicked > 2 || Time.time - clicktime > 1)
                    {
                        clicked = 0;
                    }

                }
                else if (charInfoPanel && !OverUIObject())
                {
                    //Debug.Log("Not UI");
                    charInfoPanel.SetActive(false);

                    /*
                    Vector2 currentPos = charInfoPanel.GetComponent<RectTransform>().position;
                    currentPos.x = -1000;
                    charInfoPanel.transform.position = new Vector2(currentPos.x, currentPos.y);
                    */

                    CloseAllCharInfo();
                }
            }
        }
    }

    //to check whether we are touching UI elements
    private bool OverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    private void CloseAllCharInfo()
    {
        //charStats.SetActive(false);

        foreach (Transform child in charRolesNTasks.transform)
        {
            child.gameObject.SetActive(false);
            //child.gameObject.transform.Translate(Vector3.right * 1000);
        }
    }

    private void OpenCorrectCharInfo()
    {
        //charStats.SetActive(true);

        int clickedManager = 999;
        string clickedTeammate = "0";

        if (hitInfo.transform.parent.gameObject.name == "Manager")
        {
            clickedManager = PlayerPrefs.GetInt(selectedManager);
            charStats.GetComponent<StatsDisplay>().DisplayCharacterStats(clickedManager, clickedTeammate);

            charRolesNTasks.GetComponent<RolesTasksDisplay>().DisplayCharacterRolesNTasks(hitInfo.transform.parent.gameObject.name);
            //charRolesNTasks.transform.Find("Manager Roles N Tasks").gameObject.SetActive(true);
            Debug.Log("Displaying info of: " + hitInfo.collider.gameObject.name);
        }
        else
        {
            //Display Character Stats
            switch (hitInfo.collider.gameObject.name)
            {
                case "TeamMember 1":
                    clickedTeammate = PlayerPrefs.GetString(selectedMembers[0]);
                    charStats.GetComponent<StatsDisplay>().DisplayCharacterStats(clickedManager, clickedTeammate);
                    break;
                case "TeamMember 2":
                    clickedTeammate = PlayerPrefs.GetString(selectedMembers[1]);
                    charStats.GetComponent<StatsDisplay>().DisplayCharacterStats(clickedManager, clickedTeammate);
                    break;
                case "TeamMember 3":
                    clickedTeammate = PlayerPrefs.GetString(selectedMembers[2]);
                    charStats.GetComponent<StatsDisplay>().DisplayCharacterStats(clickedManager, clickedTeammate);
                    break;
                case "TeamMember 4":
                    clickedTeammate = PlayerPrefs.GetString(selectedMembers[3]);
                    charStats.GetComponent<StatsDisplay>().DisplayCharacterStats(clickedManager, clickedTeammate);
                    break;
                case "Example Teammate":
                    charRolesNTasks.transform.Find("Roles&Tasks_Member X").gameObject.SetActive(true);
                    break;
            }

            //Display Character Roles and Tasks
            charRolesNTasks.GetComponent<RolesTasksDisplay>().DisplayCharacterRolesNTasks(hitInfo.collider.gameObject.name);

            Debug.Log("Displaying info of: " + hitInfo.collider.gameObject.name);
        }
    }
}
