using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public List<GameObject> characterFullStats;

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
        if (chacName == "Manager1_Chac")
        {
            characterFullStats[0].SetActive(true);
        }
        else if (chacName == "Manager2_Chac")
        {
            characterFullStats[1].SetActive(true);
        }
        else if (chacName == "Manager3_Chac")
        {
            characterFullStats[2].SetActive(true);
        }
        else if (chacName == "Manager4_Chac")
        {
            characterFullStats[3].SetActive(true);
        }
        else if (chacName == "Manager5_Chac")
        {
            characterFullStats[4].SetActive(true);
        }
    }

    public void Confirm()
    {
        SceneManager.LoadScene("Team_Character_Selection");
    }
}
