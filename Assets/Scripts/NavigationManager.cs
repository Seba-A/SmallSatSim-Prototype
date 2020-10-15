using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationManager : MonoBehaviour
{

    private GameObject chacObject;

    // Start is called before the first frame update
    void Start()
    {
        chacObject = GameObject.Find("Manager 1_Chac");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (chacObject.CompareTag("Character"))
        {
            chacObject.transform.Translate(Vector3.left * Time.deltaTime);
        }
    }
}
