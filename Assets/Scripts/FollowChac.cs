using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowChac : MonoBehaviour
{
    public GameObject character;

    private Vector3 characterPos;
    private Vector3 offset = new Vector3(0, -3, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        characterPos = character.transform.position;

        transform.position = characterPos + offset;

        
    }
}
