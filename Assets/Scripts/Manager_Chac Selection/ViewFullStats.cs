using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ViewFullStats : MonoBehaviour
{
    //public GameObject managerChac;
    public GameObject chacSelectScreen;

    private GameObject[] managerChac;
    private GameObject selectedChac;

    private float initialPosY;
    private float initialPosZ;

    // Start is called before the first frame update
    void Start()
    {
        managerChac = GameObject.FindGameObjectsWithTag("Character");

        initialPosY = transform.position.y;
        initialPosZ = transform.position.z;
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

        transform.position = new Vector3(-7, initialPosY, initialPosZ);
        selectedChac.SetActive(true);

        // show the Character Selection Screen
        chacSelectScreen.SetActive(true);
        Debug.Log("Full Stats of " + chacName + " has been displayed.");

    }

    
}
