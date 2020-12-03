using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TeamConfirmation : MonoBehaviour
{
    public Button confirmFullTeamButton;

    public GameObject selectionTeamManager;
    [SerializeField] private int teamMembers;

    private readonly string countLoadsToHome = "NumberOfLoadsToHomeScene";

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Rise my bois. Hail to me!");
    }

    // Update is called once per frame
    void Update()
    {
        teamMembers = selectionTeamManager.GetComponent<TeamChacManager>().noOfMemberSelected;
        if (teamMembers == 4)
        {
            confirmFullTeamButton.interactable = true;
        }
        else
        {
            confirmFullTeamButton.interactable = false;
        }
    }

    public void ConfirmTeamComposition()
    {
        PlayerPrefs.SetInt(countLoadsToHome, 0);
        //Debug.Log("number of loads to home reset to zero.");
        SceneManager.LoadScene("In_Game_Home");
    }
}
