using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Dropdown))]
public class RoleSelection : MonoBehaviour
{
    public GameObject memberAttached;
    private GameObject roleUIPanel;
    public Dropdown primaryDropdown;
    public Dropdown secondaryDropdown;

    public TextMeshProUGUI[] listOfRoles;

    private readonly string primaryRole = " PrimaryRoleOption";
    private readonly string secondaryRole = " SecondaryRoleOption";

    public void SavingRoles()
    {

        primaryDropdown.onValueChanged.AddListener(new UnityEngine.Events.UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(roleUIPanel.name + primaryRole, primaryDropdown.value);
            PlayerPrefs.Save();
        }));
        Debug.Log(primaryDropdown.value + " is selected.");


        secondaryDropdown.onValueChanged.AddListener(new UnityEngine.Events.UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(roleUIPanel.name + secondaryRole, secondaryDropdown.value);
            PlayerPrefs.Save();
        }));
        Debug.Log(secondaryDropdown.value + " is selected.");

    }

    // Start is called before the first frame update
    void Start()
    {
        roleUIPanel = this.gameObject;

        primaryDropdown.value = PlayerPrefs.GetInt(roleUIPanel.name + primaryRole, 0);
        Debug.Log("Displaying primary role: " + primaryDropdown.value);
        secondaryDropdown.value = PlayerPrefs.GetInt(roleUIPanel.name + secondaryRole, 0);
        Debug.Log("Displaying secondary role: " + secondaryDropdown.value);
    }

}
