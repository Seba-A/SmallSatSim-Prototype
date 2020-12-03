using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionRepeatCounter : MonoBehaviour
{
    public int TimesMissionIsReapeated;

    private readonly string repeatMissionCount = "NumberOfTimesMissionIsRepeated";    

    public void IncreaseRepeatCount(string missionSceneName)
    {
        TimesMissionIsReapeated = PlayerPrefs.GetInt(missionSceneName + repeatMissionCount);
        //Debug.Log(TimesMissionIsReapeated);
        TimesMissionIsReapeated++;
        //Debug.Log(TimesMissionIsReapeated);

        PlayerPrefs.SetInt(missionSceneName + repeatMissionCount, TimesMissionIsReapeated);
    }
}
