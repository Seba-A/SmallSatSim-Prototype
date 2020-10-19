using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewFullStats : MonoBehaviour
{
    //public GameObject managerChac;
    public GameObject fullStats;

    private GameObject selectedChac;
    private GameObject selectedChacName;
    private GameObject selectedChacKeyStat;

    private GameObject[] managerChac;
    private GameObject[] managerName;
    private GameObject[] managerKeyStat;

    private float initialPosY;
    private float initialPosZ;

    // Start is called before the first frame update
    void Start()
    {
        managerChac = GameObject.FindGameObjectsWithTag("Character");
        managerName = GameObject.FindGameObjectsWithTag("ChacName");
        managerKeyStat = GameObject.FindGameObjectsWithTag("ChacKeyStat");

        initialPosY = transform.position.y;
        initialPosZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        selectedChac = GameObject.Find("Manager2_Chac");
        selectedChacName = GameObject.Find("Manager2_Name");
        selectedChacKeyStat = GameObject.Find("Manager2_KeyStat");

        foreach (GameObject character in managerChac)
        {
            character.SetActive(false);
        }
        foreach (GameObject character in managerName)
        {
            character.SetActive(false);
        }
        foreach (GameObject character in managerKeyStat)
        {
            character.SetActive(false);
        }

        transform.position = new Vector3(-7, initialPosY, initialPosZ);

        selectedChac.SetActive(true);
        selectedChacName.SetActive(true);
        selectedChacKeyStat.SetActive(true);

        fullStats.SetActive(true);

    }
}
