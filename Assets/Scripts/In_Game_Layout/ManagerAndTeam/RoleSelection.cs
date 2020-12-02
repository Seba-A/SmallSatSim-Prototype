using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*  
 *  This script is attached to every Roles&Tasks_Member X prefab
 */

[RequireComponent(typeof(Dropdown))]
public class RoleSelection : MonoBehaviour
{
    public GameObject memberAttached;
    private GameObject roleUIPanel;

    public Dropdown primaryDropdown;
    public Dropdown secondaryDropdown;

    public TextMeshProUGUI primaryRoleDescription;
    public TextMeshProUGUI secondaryRoleDescription;

    public TextMeshProUGUI[] listOfRoles;

    /* generic key defined for character roles
     * For the unique key for each character, will need to add the UIPanel.name + generic key string
     */
    private readonly string primaryRole = " PrimaryRoleOption";
    private readonly string secondaryRole = " SecondaryRoleOption";


    // Start is called before the first frame update
    void Start()
    {
        roleUIPanel = this.gameObject;
        //Debug.Log(roleUIPanel.name);

        primaryDropdown.value = PlayerPrefs.GetInt(roleUIPanel.name + primaryRole, 0);
        Debug.Log("Displaying primary role: " + primaryDropdown.value);
        secondaryDropdown.value = PlayerPrefs.GetInt(roleUIPanel.name + secondaryRole, 0);
        //Debug.Log("Displaying secondary role: " + secondaryDropdown.value);
    }

    public void SavePrimaryRole()
    {
        // player preference key is the combination of UIpanel name plus the generic key
        PlayerPrefs.SetInt(roleUIPanel.name + primaryRole, primaryDropdown.value);
        PlayerPrefs.Save();
        //Debug.Log(primaryDropdown.value + " is selected.");
        //Debug.Log("Primary Role of " + memberAttached.name + " is now: " + primaryDropdown.captionText.text);

        /*
        // show the relevant role effects
        foreach (TextMeshProUGUI element in listOfRoles)
        {
            if (primaryDropdown.captionText.text == element.name.Substring(0, element.name.Length -12))
            {
                primaryRoleDescription.text = element.text;
            }
        }*/
    }

    public void SaveSecondaryRole()
    {
        // player preference key is the combination of UIpanel name plus the generic key
        PlayerPrefs.SetInt(roleUIPanel.name + secondaryRole, secondaryDropdown.value);
        PlayerPrefs.Save();
        //Debug.Log(secondaryDropdown.value + " is selected.");
        //Debug.Log("Secondary Role of " + memberAttached.name + " is now: " + secondaryDropdown.captionText.text);

        /*
        // show the relevant role effects
        foreach (TextMeshProUGUI element in listOfRoles)
        {
            if (secondaryDropdown.captionText.text == element.name.Substring(0, element.name.Length - 12))
            {
                secondaryRoleDescription.text = element.text;
            }
        }*/
    }
}
