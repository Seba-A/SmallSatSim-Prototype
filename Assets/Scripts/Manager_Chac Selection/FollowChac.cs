using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowChac : MonoBehaviour
{
    public GameObject character;

    private Vector3 characterPos;
    private Vector3 offsetName = new Vector3(0, -3, 0);
    private Vector3 offsetKeyStat = new Vector3(0, -4, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        characterPos = character.transform.position;

        if (CompareTag("ChacName"))
        {
            transform.position = characterPos + offsetName;
        }

        if (CompareTag("ChacKeyStat"))
        {
            transform.position = characterPos + offsetKeyStat;
        }

        

    }
}
