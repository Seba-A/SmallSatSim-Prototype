using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEvents : MonoBehaviour
{
    public GameManager gameManager;

    private float Elapsed = 0.0f;
    private float WaitTime = 0.0f;
    private float MinTime;
    private float MaxTime;

    void Start()
    {
        MinTime = (float)gameManager.CalculateTimeInSeconds(gameManager.TimeOfMission_Minutes) / (float)gameManager.MaxNumberOfPopUp;
        MaxTime = (float)gameManager.CalculateTimeInSeconds(gameManager.TimeOfMission_Minutes) / (float)gameManager.MinNumberOfPopUp;
        WaitTime = Random.Range(MinTime, MaxTime);

        //Debug.Log("the min time is " + MinTime);
        //Debug.Log("the max time is " + MaxTime);
        //Debug.Log("wait time" + WaitTime);
    }

    void Update()
    {
        Elapsed += Time.deltaTime;

        if (Elapsed > WaitTime)
        {
            Elapsed = 0.0f;
            WaitTime = Random.Range(MinTime, MaxTime);

            //Debug.Log("Random Event");
            //Debug.Log("New Wait Time " + WaitTime);

            //Here we should start th ecoroutine to spawn the event
            //StartCoroutine("SpawnPopUpEvent");
            //return yield null;
        }
    }
}
