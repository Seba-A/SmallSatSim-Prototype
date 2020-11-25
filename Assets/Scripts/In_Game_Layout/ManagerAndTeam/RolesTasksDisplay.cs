using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RolesTasksDisplay : MonoBehaviour
{
    private GameObject charRolesNTasks;

    // Start is called before the first frame update
    void Start()
    {
        charRolesNTasks = this.gameObject;
    }

    public void DisplayCharacterRolesNTasks(string clickedCharName)
    {
        if (clickedCharName == "Manager")
        {
            charRolesNTasks.transform.Find("Roles&Tasks_" + clickedCharName).gameObject.SetActive(true);
            Debug.Log("Manager stats OPshitz yo!");
        }
        else
        {
            string nameToCompare = clickedCharName.Substring(4, 8);
            Debug.Log("Name to compare is: " + nameToCompare);

            charRolesNTasks.transform.Find("Roles&Tasks_" + nameToCompare).gameObject.SetActive(true);
        }
    }
}
