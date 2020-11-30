using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskAssigned : MonoBehaviour
{
    //to activate timer
    public bool taskIsAssigned = false;

    //usign this to activate the timer
    void Update()
    {
        if (this.transform.parent.name == "ContentTask")
        {
            //Debug.Log("Task has been assigned");
            taskIsAssigned = true;
            (GameObject.Find(this.transform.name).GetComponent<Draggable>() as MonoBehaviour).enabled = false;
        }
        else
        {
            //Debug.Log("No task has been assigned");
            taskIsAssigned = false;
            gameObject.GetComponent<TaskTimer>().timeRemaining = gameObject.GetComponent<TaskV2>().timeRequired;

            //to reactivate the draggable script if the parents tasks are completed
            if (this.gameObject.GetComponent<TaskV2>().HasParents == true)
            {
                (GameObject.Find(this.transform.name).GetComponent<Draggable>() as MonoBehaviour).enabled = true;
            }
        }
    }
}
