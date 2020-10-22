using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public List<GameObject> characterFullStats;
    private readonly string selectedCharacter = "SelectedCharacter";

    /*
    private GameObject[] managerChac;
    private GameObject[] navObjects;
    */

    // Start is called before the first frame update
    void Start()
    {
        /*
        managerChac = GameObject.FindGameObjectsWithTag("Character");
        navObjects = GameObject.FindGameObjectsWithTag("NavArrow");
        */
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
                PlayerPrefs.SetInt(selectedCharacter, 0);
                characterFullStats[0].SetActive(true);
                break;
            case "Manager2_Chac":
                PlayerPrefs.SetInt(selectedCharacter, 1);
                characterFullStats[1].SetActive(true);
                break;
            case "Manager3_Chac":
                PlayerPrefs.SetInt(selectedCharacter, 2);
                characterFullStats[2].SetActive(true);
                break;
            case "Manager4_Chac":
                PlayerPrefs.SetInt(selectedCharacter, 3);
                characterFullStats[3].SetActive(true);
                break;
            case "Manager5_Chac":
                PlayerPrefs.SetInt(selectedCharacter, 4);
                characterFullStats[4].SetActive(true);
                break;
            default:
                PlayerPrefs.SetInt(selectedCharacter, 1);
                characterFullStats[1].SetActive(true);
                break;
        }
    }

    public void ConfirmCharacter()
    {
        SceneManager.LoadScene("Team_Character_Selection");
    }

    public void BackFunction()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        /* To improve the code, consider going back to:
         * the last known position of all characters + selected character to go back its original position.
         * 
         * Code below is incomplete.
         
        foreach (GameObject character in managerChac)
        {
            character.SetActive(true);
        }

        foreach (GameObject arrow in navObjects)
        {
            arrow.SetActive(true);
        }
        */
    }
}
