using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectUnselectMember : MonoBehaviour
{
    private readonly string selectedMember1 = "SelectedMember1";
    private readonly string selectedMember2 = "SelectedMember2";
    private readonly string selectedMember3 = "SelectedMember3";
    private readonly string selectedMember4 = "SelectedMember4";

    private Button selectButton;
    private TextMeshProUGUI selectText;
    private bool isMemberSelected = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectUnselectButton()
    {
        Debug.Log("'this' name is: " + this.name);
        selectButton = this.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(3).GetComponent<Button>();
        Debug.Log("The selected button is now: " + selectButton.name);

        selectText = selectButton.GetComponentInChildren<TextMeshProUGUI>();

        if (isMemberSelected == false)
        {
            selectText.text = "Unselect";

            isMemberSelected = true;
        }
        else
        {
            selectText.text = "Select";

            isMemberSelected = false;
        }
    }
}
