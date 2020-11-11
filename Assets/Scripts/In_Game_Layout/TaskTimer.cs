using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskTimer : MonoBehaviour
{
    public TextMeshProUGUI time;
    public float timeRemaining;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = gameObject.GetComponent<TaskV2>().timeRequired;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Draggable>().taskIsAssigned)
        {
            time.text = "Time: " + timeRemaining.ToString("0");

            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                //Debug.Log("Time has run out!");
                timeRemaining = 0;
                gameObject.GetComponent<TaskV2>().taskCompleted = true;
                Destroy(gameObject);
            }
        }
    }


}
