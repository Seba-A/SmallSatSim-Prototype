﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputeProductStats : MonoBehaviour
{
    private GameManager AddTo;
    private GameObject managerAndTeam;
    private GameObject charStats;

    int charSpeed = 0, charQuality = 0, charRelationship = 0, charFocus = 0, charCreativity = 0;

    // Start is called before the first frame update
    void Start()
    {
        AddTo = FindObjectOfType<GameManager>();
        managerAndTeam = GameObject.Find("Manager And Team");
        charStats = GameObject.Find("Canvas").transform.Find("Character Info Panel").gameObject.transform.Find("CharStats Panel").gameObject;
    }

    //increase the score value by the task's indicated values
    public void AddScore(float repeatIndex)
    {
        AddTo.redundancyScore = AddTo.redundancyScore + (int)((float)gameObject.GetComponent<TaskV2>().redundancy / repeatIndex);
        AddTo.reliabilityScore = AddTo.reliabilityScore + (int)((float)gameObject.GetComponent<TaskV2>().reliability / repeatIndex);
        AddTo.clarityScore = AddTo.clarityScore + (int)((float)gameObject.GetComponent<TaskV2>().clarity / repeatIndex);
        AddTo.efficiencyScore = AddTo.efficiencyScore + (int)((float)gameObject.GetComponent<TaskV2>().efficiency / repeatIndex);
        AddTo.innovationScore = AddTo.innovationScore + (int)((float)gameObject.GetComponent<TaskV2>().innovation / repeatIndex);


    }

    public float ScorePenalty(int CharStat, int IdealStat)
    {
        float ratioStat = (float)CharStat / (float)IdealStat;
        float ratioToMultiply = 1;

        if (ratioStat > 0.0f && ratioStat <= 0.3f)
        {
            ratioToMultiply = 0.3f;         // lower cap
        }
        else if (ratioStat > 0.3f && ratioStat <= 1.0f)
        {
            ratioToMultiply = ratioStat;
        }
        else if (ratioStat > 1.0f && ratioStat <= 1.2)
        {
            ratioToMultiply = 1.1f;
        }
        else if (ratioStat > 1.2f && ratioStat <= 1.5f)
        {
            ratioToMultiply = 1.3f;
        }
        else if (ratioStat > 1.5f && ratioStat <= 1.7f)
        {
            ratioToMultiply = 1.5f;
        }
        else if (ratioStat > 1.7f)
        {
            ratioToMultiply = 1.7f;         // upper cap
        }

        return ratioToMultiply;
    }

    // compute ratio first, then average
    public float ComputeAverage(string statToBeComputed)
    {
        float avgMultiplier = 1.0f;

        int idealSpeed = gameObject.GetComponent<TaskV2>().idealTaskSpeed;
        int idealQuality = gameObject.GetComponent<TaskV2>().idealTaskQuality;
        int idealRelationship = gameObject.GetComponent<TaskV2>().idealTaskRelationship;
        int idealFocus = gameObject.GetComponent<TaskV2>().idealTaskFocus;
        int idealCreativity = gameObject.GetComponent<TaskV2>().idealTaskCreativity;

        GetCharacterStats();

        switch (statToBeComputed)
        {
            case "Redundancy":

                break;
            case "Reliability":

                break;
            case "Clarity":

                break;
            case "Efficiency":

                break;
            case "Innovation":
                // character +relationship, -focus, +creativity
                avgMultiplier = (ScorePenalty(charRelationship, idealRelationship) + Mathf.Abs(ScorePenalty(charFocus, idealFocus) - 2) + ScorePenalty(charCreativity, idealCreativity)) / 3;
                break;
            case "TaskTime":
                // character +speed and +focus
                avgMultiplier = (ScorePenalty(charSpeed, idealSpeed) + ScorePenalty(charFocus, idealFocus))/ 2;
                break;
        }

        Debug.Log(avgMultiplier);

        return avgMultiplier;
    }

    public void GetCharacterStats()
    {
        GameObject relevantMember = gameObject.GetComponent<TaskTimer>().assignTaskPanel.transform.parent.parent.gameObject;
        int memberIndex = int.Parse(relevantMember.name.Substring(relevantMember.name.Length - 1, 1)) - 1;
        string memberName = managerAndTeam.GetComponent<GetManagerAndTeam>().confirmedTeam[memberIndex].name.Substring(0, 7);
        Debug.Log(memberName);

        int memberIndexInFullList = 999;

        foreach (GameObject element in managerAndTeam.GetComponent<GetManagerAndTeam>().teamMemberList)
        {
            string elementMemberName = element.name.Substring(0, 7);

            if (elementMemberName == memberName)
            {
                memberIndexInFullList = System.Array.IndexOf(managerAndTeam.GetComponent<GetManagerAndTeam>().teamMemberList, element);
                Debug.Log(memberIndexInFullList);
            }
        }

        CharacterInfo relevantMemberInfo = charStats.GetComponent<StatsDisplay>().memberStatsList[memberIndexInFullList];

        charSpeed = relevantMemberInfo.speed;
        Debug.Log(charSpeed);

        charQuality = relevantMemberInfo.quality;
        Debug.Log(charQuality);

        charRelationship = relevantMemberInfo.relationship;
        Debug.Log(charRelationship);

        charFocus = relevantMemberInfo.focus;
        Debug.Log(charFocus);

        charCreativity = relevantMemberInfo.creativity;
        Debug.Log(charCreativity);
    }
}
