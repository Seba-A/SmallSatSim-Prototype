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
    private float lowerBound = -14.0f;
    private float upperBound = 14.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && chacManager.transform.position.x < upperBound)
        {
            chacManager.transform.Translate(Vector3.right * navDist);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && chacManager.transform.position.x > lowerBound)
        {
            chacManager.transform.Translate(Vector3.left * navDist);
        }
    }

    public void NavigateWithClick(string arrowName)
    {
        clickedArrow = GameObject.Find(arrowName);

        if (clickedArrow == leftNavArrow && chacManager.transform.position.x < upperBound)
        {
            chacManager.transform.Translate(Vector3.right * navDist);
        }

        else if (clickedArrow == rightNavArrow && chacManager.transform.position.x > lowerBound)
        {
            chacManager.transform.Translate(Vector3.left * navDist);
        }

    }
}
