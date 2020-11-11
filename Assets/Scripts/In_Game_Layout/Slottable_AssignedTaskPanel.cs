using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Slottable_AssignedTaskPanel : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public string assignedFirstTaskName;
    public bool isFirstSlotFilled = false;

    public TextMeshProUGUI time;
    private int taskDuration = 10;

    Draggable taskDropped = null;
    [SerializeField] private GameObject assignedFirstTask;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);

        taskDropped = eventData.pointerDrag.GetComponent<Draggable>();
        if (taskDropped != null)
        {
            taskDropped.parentToReturnTo = this.transform;

            taskDropped.transform.SetParent(this.transform); 
            Debug.Log(taskDropped.transform.parent.name);
        }

        CheckIfFirstChild();
    }

    public void CheckIfFirstChild()
    {
        if (this.transform.GetChild(0) != null)
        {
            isFirstSlotFilled = true;

            assignedFirstTask = taskDropped.gameObject;
            assignedFirstTaskName = taskDropped.name;
            Debug.Log(assignedFirstTaskName);

            // trigger the timer
            StartCoroutine(CountDownTimer());

            // add score
            //GameObject.Find("GameManager").GetComponent<GameManager>().AddScore();
        }
    }

    IEnumerator CountDownTimer()
    {
        while (isFirstSlotFilled == true)
        {
            yield return new WaitForSeconds(1);
            UpdateTimer(1);
            Debug.Log("the task duration left: " + taskDuration);

            if (taskDuration == 0)
            {
                Destroy(assignedFirstTask);
                isFirstSlotFilled = false;

                // reset timer
                taskDuration = 10;

                // re-check first child
                CheckIfFirstChild();
            }
        }
    }

    public void UpdateTimer(int timeToMinus)
    {
        taskDuration -= timeToMinus;
        time.text = "Time: " + taskDuration;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("OnPointerEnter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("OnPointerExit");
    }
}