using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockATask : MonoBehaviour
{
    public List<GameObject> TasksToCompleteFirstList;

    public bool UnlockTask = false;

    //int NumberOfTasksToComplete;

    // Start is called before the first frame update
    void Start()
    {
        //NumberOfTasksToComplete = TasksToCompleteFirstList.Count;
    }

    // Update is called once per frame
    void Update()
    {
        //This is for the version that sits on the taskk that needs to be completed first (Old Version)
        //CheckFor();

        CheckIfRequiredTaskIsCompleted();
    }

    /*
    public void CheckFor()
    {
        foreach(GameObject target in Targets)
        {
            //parentMission.transform.Find(this.transform.name).GetComponent<TaskTimer>().FirstTimeCompletion
            if (gameObject.GetComponent<TaskTimer>().FirstTimeCompletion)
            {
                (target.GetComponent<Draggable>() as MonoBehaviour).enabled = true;
                UnlockTask = true;
                
                Debug.Log(target.transform.name);
            }
            else
            {
                (target.GetComponent<Draggable>() as MonoBehaviour).enabled = false;
            }
        }
    }*/

    public void CheckIfRequiredTaskIsCompleted()
    {
        foreach(GameObject target in TasksToCompleteFirstList)
        {
            if (target.GetComponent<TaskTimer>().FirstTimeCompletion)
            {
                UnlockTask = true;
                Debug.Log("Task completed");
            }
            else
            {
                (this.gameObject.GetComponent<Draggable>() as MonoBehaviour).enabled = false; UnlockTask = false;
                UnlockTask = false;
                Debug.Log("Not completed");
                break;
            }
        }

        if (UnlockTask == true)
        {
            (this.gameObject.GetComponent<Draggable>() as MonoBehaviour).enabled = false; UnlockTask = true;
            Debug.Log("Unlock the task");
        }
    }
}
