using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotate : MonoBehaviour
{
    private float rotateSpeed = 50.0f;
    //private float upwardForce = 50.0f;

    private Vector3 initialPos;
    private Quaternion initialRot;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
        initialRot = transform.rotation;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {
        if (CompareTag("RightNavArrow") || CompareTag("LeftNavArrow"))
        {
            transform.Rotate(Vector3.up, Time.deltaTime * rotateSpeed);
        }
        
        if (CompareTag("Character"))
        {
            transform.Rotate(Vector3.up, Time.deltaTime * rotateSpeed);

            /*
            // does not work!! How do you only make the Character have a "Rigid body" and not the NavArrow?

            Rigidbody chacRb = GetComponent<Rigidbody>();

            chacRb.useGravity = true;
            if (initialPos.y - transform.position.y > 0)
            {
                chacRb.AddForce(Vector3.up * upwardForce, ForceMode.Force);
            }
            */
        }
        
    }

    private void OnMouseExit()
    {
        if (CompareTag("RightNavArrow") || CompareTag("LeftNavArrow"))
        {
            transform.rotation = initialRot;
        }

        if (CompareTag("Character"))
        {
            transform.rotation = initialRot;
        }
    }

}
