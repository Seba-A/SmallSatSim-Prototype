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

    // Start is called before the first frame update
    void Start()
    {
        managerChac = GameObject.FindGameObjectsWithTag("Character");
        navObjects = GameObject.FindGameObjectsWithTag("NavArrow");

        //initialPosY = transform.position.y;
        //initialPosZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ViewFullChacStats(string chacName)
    {
        selectedChac = GameObject.Find(chacName);
        Debug.Log("Selected character is now " + chacName);

        foreach (GameObject character in managerChac)
        {
            character.SetActive(false);
        }

        foreach (GameObject arrow in navObjects)
        {
            arrow.SetActive(false);
        }

        selectedChac.transform.position = new Vector3(-7.0f, 6.0f, 0.0f);
        selectedChac.SetActive(true);

        // show the Character Selection Screen
        chacSelectScreen.SetActive(true);
        chacSelectScreen.GetComponent<CharacterSelection>().DisplayChacFullStats(chacName);
        Debug.Log("Full Stats of " + chacName + " has been displayed.");

    }

    
}
