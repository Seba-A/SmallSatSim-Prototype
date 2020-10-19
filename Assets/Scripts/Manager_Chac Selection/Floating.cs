using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    /* WILL NEED TO REVIEW AGAIN
     * HOW. HOW TO MAKE IT FLOAT. GOD DAMN IT.
     */

    private Rigidbody chacRb;

    private Vector3 initialPos;
    private float upwardForce = 20.0f;

    private bool isMouseOver = false;

    // Start is called before the first frame update
    void Start()
    {
        chacRb = GetComponent<Rigidbody>();
        initialPos = transform.position;

        chacRb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMouseOver == false && (initialPos.y - transform.position.y != 0))
        {
            transform.position = initialPos;
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }

    private void OnMouseOver()
    {
        isMouseOver = true;
        chacRb.useGravity = true;

        if (initialPos.y - transform.position.y > 0)
        {
            chacRb.AddForce(Vector3.up * upwardForce, ForceMode.Force);
        }
        /*else if(initialPos.y - transform.position.y < 0)
        {
            chacRb.AddForce(Vector3.up * -upwardForce, ForceMode.Force);
        }*/
    }

    private void OnMouseExit()
    {
        isMouseOver = false;

        chacRb.useGravity = false;
    }



}
