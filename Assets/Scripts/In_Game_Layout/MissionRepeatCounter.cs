using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionRepeatCounter : MonoBehaviour
{
    public int TimesMissionIsReapeated;
    
    // Start is called before the first frame update
    void Start()
    {
        TimesMissionIsReapeated = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IncreaseRepeatCount()
    {
        TimesMissionIsReapeated++;
    }
}
