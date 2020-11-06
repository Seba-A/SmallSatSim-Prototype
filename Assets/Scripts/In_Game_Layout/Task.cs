using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Task", menuName = "Task")]
public class Task : ScriptableObject
{
    public new string name;
    public string description;

    public float timeRequired;
    public bool timerIsRunning = false;

    public int redundancy;
    public int reliability;
    public int clarity;
    public int efficiency;
    public int innovation;
}
