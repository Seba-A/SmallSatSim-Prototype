using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotate : MonoBehaviour
{
    private float rotateSpeed = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (CompareTag("NavArrow"))
        {
            transform.Rotate(Vector3.up, Time.deltaTime * rotateSpeed);
        }

        if (CompareTag("Character"))
        {

        }

    }

   
}
