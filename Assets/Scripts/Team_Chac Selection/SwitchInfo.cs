using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchInfo : MonoBehaviour
{
    private bool summaryStats = true;

    public GameObject chacSummary;
    public GameObject chacMoreInfo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchCharacterInfo()
    {
        if (summaryStats == true)
        {
            chacSummary.SetActive(false);
            chacMoreInfo.SetActive(true);

            summaryStats = false;
        }
        else
        {
            chacSummary.SetActive(true);
            chacMoreInfo.SetActive(false);

            summaryStats = true;
        }
    }
}
