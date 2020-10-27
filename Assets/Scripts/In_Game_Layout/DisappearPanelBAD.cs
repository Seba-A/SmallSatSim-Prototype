using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DisappearPanelBAD : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.gameObject.SetActive(ClickingSelfOrChild());
        }
    }
    private bool ClickingSelfOrChild()
    {
        RectTransform[] rectTransforms = GetComponentsInChildren<RectTransform>();
        foreach (RectTransform rectTransform in rectTransforms)
        {
            if (EventSystem.current.currentSelectedGameObject == rectTransform.gameObject)
            {
                return true;
            };
        }
        return false;
    }
}
