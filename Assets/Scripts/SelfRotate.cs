using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CompareTag("NavArrow"))
        {
            transform.Rotate(Vector3.up, Time.deltaTime * 40.0f);
        }
    }

    private void OnMouseEnter()
    {

        
    }
}
