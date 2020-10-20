using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotate : MonoBehaviour
{
    private float rotateSpeed = 50.0f;
    //private float upwardForce = 50.0f;

    private Vector3 initialPos;
    private Quaternion initialRot;

    public bool isObjectClicked;
    public string nameObjectClicked;

    private GameObject chacManager;

    // Start is called before the first frame update
    void Start()
    { 
        initialPos = transform.position;
        initialRot = transform.rotation;

        isObjectClicked = false;

        chacManager = GameObject.Find("Character Manager");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * rotateSpeed);
    }

    private void OnMouseExit()
    {
        transform.rotation = initialRot;
    }

    private void OnMouseUpAsButton()
    {
        if (CompareTag("Character"))
        {
            isObjectClicked = true;
        }

        findNameObjectClicked();
        Debug.Log(nameObjectClicked + " is clicked.");

        chacManager.GetComponent<ViewFullStats>().ViewFullChacStats(nameObjectClicked);

    }

    public string findNameObjectClicked()
    {
        if (isObjectClicked == true)
        {
            nameObjectClicked = this.name;
        }

        return nameObjectClicked;

    }

}
