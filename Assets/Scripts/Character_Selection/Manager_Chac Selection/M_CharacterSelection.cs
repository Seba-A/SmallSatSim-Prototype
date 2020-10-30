using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class M_CharacterSelection : MonoBehaviour
{
    public List<GameObject> characterFullStats;
    private readonly string selectedManager = "SelectedManager";

    private GameObject mainCharacter;

    public GameObject teamStatsUI;
    public GameObject managerObjects, teamObjects, managerSelection, teamSelection, managerInstructions, teamInstructions;
    public GameObject chacManager;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DisplayChacFullStats(string chacName)
    {
        switch (chacName)
        {
            case "Manager1_Chac":
                PlayerPrefs.SetInt(selectedManager, 0);
                characterFullStats[0].SetActive(true);
                break;
            case "Manager2_Chac":
                PlayerPrefs.SetInt(selectedManager, 1);
                characterFullStats[1].SetActive(true);
                break;
            case "Manager3_Chac":
                PlayerPrefs.SetInt(selectedManager, 2);
                characterFullStats[2].SetActive(true);
                break;
            case "Manager4_Chac":
                PlayerPrefs.SetInt(selectedManager, 3);
                characterFullStats[3].SetActive(true);
                break;
            case "Manager5_Chac":
                PlayerPrefs.SetInt(selectedManager, 4);
                characterFullStats[4].SetActive(true);
                break;
            default:
                PlayerPrefs.SetInt(selectedManager, 1);
                characterFullStats[1].SetActive(true);
                break;
        }
    }

    public void ConfirmCharacter()
    {
        // switch to team selection
        managerObjects.SetActive(false);
        teamObjects.SetActive(true);
        teamStatsUI.SetActive(true);
        managerSelection.SetActive(false);
        teamSelection.SetActive(true);
        managerInstructions.SetActive(false);
        teamInstructions.SetActive(true);
        Debug.Log("Now time to select your team.");

        // get the selected character as the main character
        mainCharacter = GameObject.Find("MainChac");
        mainCharacter.GetComponent<GetMainChac>().GetMainCharacter();
    }

    public void BackFunction()
    {
        foreach (GameObject statsWindow in characterFullStats)
        {
            statsWindow.SetActive(false);
        }

        chacManager.GetComponent<ViewFullStats>().HideFullChacStats();
    }
}
