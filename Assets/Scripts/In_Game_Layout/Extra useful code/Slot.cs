using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool isEntered;

    public void OnPointerEnter(PointerEventData eventData)
    {
        isEntered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isEntered = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (isEntered)
            {
                if (DragHandler.itemBeingDragged)
                {
                    GameObject draggedItem = DragHandler.itemBeingDragged;
                    DragHandler dragHandler = draggedItem.GetComponent<DragHandler>();
                    Vector3 childPos = draggedItem.transform.position;
                    //Debug.Log("On Pointer Enter");
                    draggedItem.transform.SetParent(dragHandler.StartParent);
                    draggedItem.transform.localPosition = dragHandler.StartPos;
                    draggedItem.transform.parent.SetParent(transform);
                    draggedItem.transform.parent.position = childPos;
                    isEntered = false;
                }
            }
        }
    }
}
