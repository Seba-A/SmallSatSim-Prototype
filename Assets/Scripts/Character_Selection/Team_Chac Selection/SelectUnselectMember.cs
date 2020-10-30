using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectUnselectMember : MonoBehaviour
{
    private Button selectButton;
    private TextMeshProUGUI selectText;
    public GameObject parentObject;

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
        // Get text and change it
        selectText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        ChangeButtonText();

        // Get attached parent
        parentObject = GetComponent<GameObject>();
        parentObject = GameObject.Find(transform.parent.name);
    }

    private void ChangeButtonText()
    {
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
