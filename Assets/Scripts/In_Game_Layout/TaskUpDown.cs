using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskUpDown : MonoBehaviour
{
    int task_IndexNumber;
    int numberOfTasksInList;

    void Update()
    {
        if (gameObject.GetComponent<Draggable>().justAssigned)
        {
            task_IndexNumber = numberOfTasksInList;
            transform.SetSiblingIndex(task_IndexNumber);
            gameObject.GetComponent<Draggable>().justAssigned = false;
        }
        else
        {
            task_IndexNumber = transform.GetSiblingIndex();
            transform.SetSiblingIndex(task_IndexNumber);
            //Debug.Log(task_IndexNumber);
        }

        numberOfTasksInList = transform.parent.transform.childCount - 1;
    }

    public void IncreaseIndex()
    {
        if (task_IndexNumber < numberOfTasksInList)
        {
            task_IndexNumber++;
            transform.SetSiblingIndex(task_IndexNumber);
        }
    }

    public void DecreaseIndex()
    {
        if (task_IndexNumber >= 1)
        {
            task_IndexNumber--;
            transform.SetSiblingIndex(task_IndexNumber);
        }
    }
}
