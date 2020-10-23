using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ViewFullStats : MonoBehaviour
{
    //public GameObject managerChac;
    public GameObject chacSelectScreen;

    private GameObject[] managerChac;
    private GameObject[] navObjects;

    public GameObject selectedChac;
    private Vector3 selectedChacPos = new Vector3(-8.0f, 6.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        managerChac = GameObject.FindGameObjectsWithTag("Character");
        navObjects = GameObject.FindGameObjectsWithTag("NavArrow");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ViewFullChacStats(string chacName)
    {
        // find selected character
        selectedChac = GameObject.Find(chacName);
        Debug.Log("Selected character is now " + chacName);

        // hide all other unselected objects
        foreach (GameObject character in managerChac)
        {
            character.SetActive(false);
        }

        foreach (GameObject arrow in navObjects)
        {
            arrow.SetActive(false);
        }

        // move selected character to one side of the screen
        selectedChac.transform.position = selectedChacPos;
        selectedChac.SetActive(true);

        // show the Character Selection Screen
        chacSelectScreen.SetActive(true);
        chacSelectScreen.GetComponent<CharacterSelection>().DisplayChacFullStats(chacName);
        Debug.Log("Full Stats of " + chacName + " has been displayed.");

    }

    
}
