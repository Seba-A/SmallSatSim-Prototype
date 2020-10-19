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

    private GameObject gameObject;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject = GameObject.Find("Character Manager").GetComponent<ViewFullStats>();

        initialPos = transform.position;
        initialRot = transform.rotation;

        isObjectClicked = false;
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

        gameObject.View

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
