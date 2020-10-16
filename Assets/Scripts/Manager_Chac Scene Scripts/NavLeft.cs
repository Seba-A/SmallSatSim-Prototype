using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavLeft : MonoBehaviour
{

    private GameObject mainCamera;
    private GameObject rightArrowSelect;
    private GameObject leftArrowSelect;

    private float navDist = 7.0f;

    private float initialCamPosX;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        rightArrowSelect = GameObject.FindGameObjectWithTag("RightNavArrow");
        leftArrowSelect = GameObject.FindGameObjectWithTag("LeftNavArrow");

        initialCamPosX = mainCamera.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            for(int i = 1; i < 8; i++)
            {
                mainCamera.transform.Translate(Vector3.right);
                rightArrowSelect.transform.Translate(Vector3.up);
                leftArrowSelect.transform.Translate(Vector3.down);
                
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            mainCamera.transform.Translate(Vector3.left * navDist);
            rightArrowSelect.transform.Translate(Vector3.down * navDist);
            leftArrowSelect.transform.Translate(Vector3.up * navDist);
        }
    }
    
    private void OnMouseDown()
    {
        mainCamera.transform.Translate(Vector3.left * navDist);
        rightArrowSelect.transform.Translate(Vector3.down * navDist);
        leftArrowSelect.transform.Translate(Vector3.up * navDist);
    }
}
