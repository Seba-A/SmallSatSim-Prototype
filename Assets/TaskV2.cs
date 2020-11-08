﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class TaskV2 : MonoBehaviour
{
    public new string name;
    public string description;

    public float timeRequired;

    public int redundancy;
    public int reliability;
    public int clarity;
    public int efficiency;
    public int innovation;
    public int progressbar;

    public TextMeshProUGUI nameTask;
    public TextMeshProUGUI descriptionText;

    // Start is called before the first frame update
    void Start()
    {
        nameTask.text = name;
        descriptionText.text = description;
    }
}
