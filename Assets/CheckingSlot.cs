﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingSlot : MonoBehaviour
{
    public bool timerIsRunning = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.parent.name == "ContentTask")
        {
            Debug.Log("Task has been assigned");
            timerIsRunning = true;
        }
        else
        {
            Debug.Log("No task has been assigned");
            timerIsRunning = false;
        }
    }
}
