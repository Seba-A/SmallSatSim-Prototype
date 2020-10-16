using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavRight : MonoBehaviour
{

    private GameObject mainCamera;
    private GameObject rightArrowSelect;
    private GameObject leftArrowSelect;

    private GameObject[] chacObj;

    private float navDist = 7.0f;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        rightArrowSelect = GameObject.FindGameObjectWithTag("RightNavArrow");
        leftArrowSelect = GameObject.FindGameObjectWithTag("LeftNavArrow");

        chacObj = GameObject.FindGameObjectsWithTag("Character");

    }

    // Update is called once per frame
    void Update()
    {
        /* already present in NavLeft script
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            mainCamera.transform.Translate(Vector3.right * navDist);
            rightArrowSelect.transform.Translate(Vector3.up * navDist);
            leftArrowSelect.transform.Translate(Vector3.down * navDist);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            mainCamera.transform.Translate(Vector3.left * navDist);
            rightArrowSelect.transform.Translate(Vector3.down * navDist);
            leftArrowSelect.transform.Translate(Vector3.up * navDist);
        }
        */
    }
    
    private void OnMouseDown()
    {
        foreach (GameObject character in chacObj)
        {
            character.transform.Translate(Vector3.right * navDist);

        }
        /*
        mainCamera.transform.Translate(Vector3.right * navDist);
        rightArrowSelect.transform.Translate(Vector3.up * navDist);
        leftArrowSelect.transform.Translate(Vector3.down * navDist);
        */
    }
}
