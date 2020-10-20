using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationManager : MonoBehaviour
{
    public GameObject chacManager;
    public GameObject leftNavArrow;
    public GameObject rightNavArrow;

    private GameObject clickedArrow;

    private float navDist = 7.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            chacManager.transform.Translate(Vector3.left * navDist);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            chacManager.transform.Translate(Vector3.right * navDist);
        }
    }

    public void NavigateWithClick(string arrowName)
    {
        clickedArrow = GameObject.Find(arrowName);

        if (clickedArrow == leftNavArrow)
        {
            chacManager.transform.Translate(Vector3.left * navDist);
        }

        else if (clickedArrow == rightNavArrow)
        {
            chacManager.transform.Translate(Vector3.right * navDist);
        }

    }
}
