﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMainChac : MonoBehaviour
{
    public GameObject[] managerChac;
    private GameObject myManager;

    private readonly string selectedManager = "SelectedManager";
    
    // Start is called before the first frame update
    void Start()
    {
        myManager = this.GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GetMainCharacter()
    {
        int getCharacter;

        getCharacter = PlayerPrefs.GetInt(selectedManager);

        switch (getCharacter)
        {
            case 0:
                myManager = Instantiate(managerChac[0], this.transform.position, this.transform.rotation);
                break;
            case 1:
                myManager = Instantiate(managerChac[1], this.transform.position, this.transform.rotation);
                break;
            case 2:
                myManager = Instantiate(managerChac[2], this.transform.position, this.transform.rotation);
                break;
            case 3:
                myManager = Instantiate(managerChac[3], this.transform.position, this.transform.rotation);
                break;
            case 4:
                myManager = Instantiate(managerChac[4], this.transform.position, this.transform.rotation);
                break;
            default:
                myManager = Instantiate(managerChac[1], this.transform.position, this.transform.rotation);
                break;
        }

        //Debug.Log(myManager.name + " is now the selected Manager.");

        //making the instantiated manager a child of myManager
        myManager.transform.parent = this.transform;
    }

    public void DeleteOldCharacter()
    {
        foreach (Transform child in this.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        //Debug.Log("Previously selected manager is deleted.");
    }
}
