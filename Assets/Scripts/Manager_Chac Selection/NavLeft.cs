using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavLeft : MonoBehaviour
{

    private GameObject mainCamera;
    private GameObject rightArrowSelect;
    private GameObject leftArrowSelect;

    private GameObject[] chacObj;

    private float navDist = 7.0f;

    private const float initialPosY = 6.0f;
    private const float initialPosZ = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        /*
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        rightArrowSelect = GameObject.FindGameObjectWithTag("RightNavArrow");
        leftArrowSelect = GameObject.FindGameObjectWithTag("LeftNavArrow");
        */
        chacObj = GameObject.FindGameObjectsWithTag("Character");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            foreach (GameObject character in chacObj)
            {
                character.transform.Translate(Vector3.left * navDist);

                //character.transform.position = new Vector3(character.transform.position.x, initialPosY, initialPosZ);

            }
            /*
            mainCamera.transform.Translate(Vector3.left * navDist);
            rightArrowSelect.transform.Translate(Vector3.down * navDist);
            leftArrowSelect.transform.Translate(Vector3.up * navDist);
            */
        }
    }
    
    private void OnMouseDown()
    {
        foreach (GameObject character in chacObj)
        {
            character.transform.Translate(Vector3.left * navDist);

            character.transform.position = new Vector3(character.transform.position.x, initialPosY, initialPosZ);
        }
        /*
        mainCamera.transform.Translate(Vector3.left * navDist);
        rightArrowSelect.transform.Translate(Vector3.down * navDist);
        leftArrowSelect.transform.Translate(Vector3.up * navDist);
        */
    }
}
