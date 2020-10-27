using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickingOnTeam : MonoBehaviour
{
    public GameObject stats;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.gameObject.tag == "Team")
                {
                    Debug.Log(gameObject.tag);
                    stats.SetActive(true);
                }
            }
        }
    }
}
