using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectionManager : MonoBehaviour
{
    private Button selectButton;
    private TextMeshProUGUI selectText;
    [SerializeField] private GameObject parentObject;

    private GameObject selectionTeamManager;
    private bool isMemberSelected = false;

    // Start is called before the first frame update
    void Start()
    {
        selectButton = transform.GetComponent<Button>();
        selectText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        selectionTeamManager = GameObject.Find("T_Character Selection");
    }

    // Update is called once per frame
    void Update()
    {
        if (selectionTeamManager.GetComponent<TeamChacManager>().noOfMemberSelected == 4 && isMemberSelected == false)
        {
            selectButton.interactable = false;
        }
        else
        {
            selectButton.interactable = true;
        }
    }


    public void SelectUnselectMemberFunction()
    {
        // Get attached parent
        parentObject = GetComponent<GameObject>();
        parentObject = GameObject.Find(transform.parent.name);

        // Change text and save/unsave member
        if (isMemberSelected == false)
        {
            selectText.text = "Unselect";

            Debug.Log(parentObject.name + " is selected.");

            // Save selected member
            selectionTeamManager.GetComponent<TeamChacManager>().SaveSelectedMember(parentObject.name);

            isMemberSelected = true;
            selectionTeamManager.GetComponent<TeamChacManager>().noOfMemberSelected++;
        }
        else
        {
            selectText.text = "Select";

            Debug.Log(parentObject.name + " is unselected.");

            isMemberSelected = false;
            selectionTeamManager.GetComponent<TeamChacManager>().noOfMemberSelected--;
        }

        // Update number of team members player have actually selected
        Debug.Log("Number of members selected is now: " + selectionTeamManager.GetComponent<TeamChacManager>().noOfMemberSelected);
    }
}
