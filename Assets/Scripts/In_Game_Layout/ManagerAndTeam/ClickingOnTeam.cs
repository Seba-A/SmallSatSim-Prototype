using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickingOnTeam : MonoBehaviour
{
    [SerializeField] private GameObject charInfoPanel;
    [SerializeField] private GameObject charStats;
    [SerializeField] private GameObject charRolesNTasks;

    private GameObject selectedManager;

    private readonly string[] selectedMembers = new string[4];

    void Start()
    {
        charInfoPanel = GameObject.Find("Canvas").transform.Find("Character Info Panel").gameObject;
        charStats = charInfoPanel.transform.Find("ChacStats Placeholder").gameObject;
        charRolesNTasks = charInfoPanel.transform.Find("Roles & Tasks Placeholder").gameObject;

        // defining Keys used for storing team members' name
        selectedMembers[0] = "SelectedMember1";
        selectedMembers[1] = "SelectedMember2";
        selectedMembers[2] = "SelectedMember3";
        selectedMembers[3] = "SelectedMember4";

        selectedManager = GameObject.Find("Manager And Team");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.gameObject.tag == "Teammate")
                {
                    charInfoPanel.SetActive(true);
                    CloseAllChar_Stats_Roles_Tasks();       //function added here to avoid more than one character info opening at the same time


                    switch (hitInfo.collider.gameObject.name)
                    {
                        case ("Manager"):
                            //charStats.transform.Find("ManagerFullStats").gameObject.SetActive(true);
                            //charRolesNTasks.transform.Find("Manager Roles N Tasks").gameObject.SetActive(true);
                            Debug.Log("Displaying info of: " + hitInfo.collider.gameObject.name);
                            break;
                        case "TeamMember 1":
                            charStats.transform.Find(PlayerPrefs.GetString(selectedMembers[0])).gameObject.SetActive(true);
                            //charRolesNTasks.transform.Find("Member[0] Roles N Tasks").gameObject.SetActive(true);
                            Debug.Log("Displaying info of: " + hitInfo.collider.gameObject.name);
                            break;
                        case "TeamMember 2":
                            charStats.transform.Find(PlayerPrefs.GetString(selectedMembers[1])).gameObject.SetActive(true);
                            //charRolesNTasks.transform.Find("Member[1] Roles N Tasks").gameObject.SetActive(true);
                            Debug.Log("Displaying info of: " + hitInfo.collider.gameObject.name);
                            break;
                        case "TeamMember 3":
                            charStats.transform.Find(PlayerPrefs.GetString(selectedMembers[2])).gameObject.SetActive(true);
                            //charRolesNTasks.transform.Find("Member[2] Roles N Tasks").gameObject.SetActive(true);
                            Debug.Log("Displaying info of: " + hitInfo.collider.gameObject.name);
                            break;
                        case "TeamMember 4":
                            charStats.transform.Find(PlayerPrefs.GetString(selectedMembers[3])).gameObject.SetActive(true);
                            //charRolesNTasks.transform.Find("Member[3] Roles N Tasks").gameObject.SetActive(true);
                            Debug.Log("Displaying info of: " + hitInfo.collider.gameObject.name);
                            break;
                        case "Example Teammate":
                            charRolesNTasks.transform.Find("Stats_Tasks").gameObject.SetActive(true);
                            Debug.Log("Displaying info of: " + hitInfo.collider.gameObject.name);
                            break;
                    }
                }
                else if (charInfoPanel && !OverUIObject())
                {
                    //Debug.Log("Not UI");
                    charInfoPanel.SetActive(false);
                    CloseAllChar_Stats_Roles_Tasks();
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

    private void CloseAllChar_Stats_Roles_Tasks()
    {
        foreach (Transform child in charStats.transform)
        {
            child.gameObject.SetActive(false);
        }

        foreach (Transform child in charRolesNTasks.transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    /*
    // double-clicking function from https://forum.unity.com/threads/detect-double-click-on-something-what-is-the-best-way.476759/
    public class GestionClickInventaire : MonoBehaviour, IPointerDownHandler
    {
        float clicked = 0;
        float clicktime = 0;
        float clickdelay = 0.5f;

        public void OnPointerDown(PointerEventData data)
        {
            clicked++;
            if (clicked == 1) clicktime = Time.time;

            if (clicked > 1 && Time.time - clicktime < clickdelay)
            {
                clicked = 0;
                clicktime = 0;
                Debug.Log("Double CLick: " + this.GetComponent<RectTransform>().name);

            }
            else if (clicked > 2 || Time.time - clicktime > 1) clicked = 0;

        }
    }*/
}
