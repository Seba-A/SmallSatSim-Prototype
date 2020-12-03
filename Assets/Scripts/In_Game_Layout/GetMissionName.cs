using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMissionName : MonoBehaviour
{
    private GameObject gameManager;
    public readonly string lastMissionPlayed = "LastMissionPlayed";

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager_Home");
    }

    public void GetSelectedMissionName()
    {
        string selectedMission = this.transform.parent.name;
        //Debug.Log(selectedMission + " is selected!!!!");

        PlayerPrefs.SetString(lastMissionPlayed, selectedMission);
        gameManager.GetComponent<GameManager_Home>().lastMissionSelected = selectedMission;
        gameManager.GetComponent<GameManager_Home>().DisplaySelectedMission(selectedMission);
    }
}
