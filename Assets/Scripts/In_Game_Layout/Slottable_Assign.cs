using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Slottable_Assign : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public bool startNextTask = true;

    public string assignedFirstTaskName;

    Draggable taskDropped = null;
    [SerializeField] private GameObject assignedFirstTask;

    //list to add name of stuff that is dropped into the list
    public List<string> tasks = new List<string>();

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);

        taskDropped = eventData.pointerDrag.GetComponent<Draggable>();
        if (taskDropped != null)
        {
            taskDropped.parentToReturnTo = this.transform;

            taskDropped.transform.SetParent(this.transform);
            //Debug.Log(taskDropped.transform.parent.name);

            taskDropped.GetComponent<TaskTimer>().assignTaskPanel = this.gameObject;

            taskDropped.justAssigned = true;

            CheckIfFirstChild();
        }
    }

    public void CheckIfFirstChild()
    {
        if (this.transform.GetChild(0) != null)
        {
            assignedFirstTask = taskDropped.gameObject;
            assignedFirstTaskName = taskDropped.name;
            //Debug.Log(assignedFirstTaskName);

            //add the name of the object dropped into the list
            tasks.Add(assignedFirstTaskName);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("OnPointerEnter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("OnPointerExit");
    }

    public void Update()
    {
        //this is to check if the task names in a list is still a child of the assign panel
        Debug.Log(tasks.Count);
        if (tasks.Count > 0)
        {
            foreach(string i in tasks)
            {
                if(this.transform.GetChild(0).name == i)
                {
                    (GameObject.Find(i).GetComponent<TaskTimer>() as MonoBehaviour).enabled = true;
                    //Debug.Log(this.transform.GetChild(0).name);
                }
                else
                {
                    (GameObject.Find(i).GetComponent<TaskTimer>() as MonoBehaviour).enabled = false;
                }
            }
        }        
    }
}