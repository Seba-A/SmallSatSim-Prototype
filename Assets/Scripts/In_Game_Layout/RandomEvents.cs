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

    public int StageIndex = 0;

    public List<GameObject> Phase0Roadblocks;
    public List<GameObject> PhaseARoadblocks;
    public List<GameObject> PhaseBRoadblocks;
    public List<GameObject> PhaseCRoadblocks;
    public List<GameObject> PhaseDRoadblocks;

    public int N_PhaseA;
    public int N_PhaseB;
    public int N_PhaseC;
    public int N_PhaseD;

    private List<GameObject> RoadblocksToAppear;

    void Start()
    {
        MinTime = (float)gameManager.CalculateTimeInSeconds(gameManager.TimeOfMission_Minutes) / (float)gameManager.MaxNumberOfPopUp;
        MaxTime = (float)gameManager.CalculateTimeInSeconds(gameManager.TimeOfMission_Minutes) / (float)gameManager.MinNumberOfPopUp;
        WaitTime = Random.Range(MinTime, MaxTime);

        //Debug.Log("the min time is " + MinTime);
        //Debug.Log("the max time is " + MaxTime);
        //Debug.Log("wait time" + WaitTime);

        //Count of number of roadblocks of each phase
        N_PhaseA = PhaseARoadblocks.Count;
        N_PhaseB = PhaseBRoadblocks.Count;
        N_PhaseC = PhaseCRoadblocks.Count;
        N_PhaseD = PhaseDRoadblocks.Count;
    }

    void Update()
    {
        Elapsed += Time.deltaTime;

        if (Elapsed > WaitTime)
        {
            //Debug.Log("Random Event");
            Elapsed = 0.0f;
            WaitTime = Random.Range(MinTime, MaxTime);
            //Debug.Log("New Wait Time " + WaitTime);

            //Here we should start th ecoroutine to spawn the event
            //StartCoroutine("SpawnPopUpEvent");
            //return yield null;
        }
    }

    //these  functions will be used to know from which lists we can pull a roadblock
    public void IncreaseStageIndex()
    {
        StageIndex++;
    }
    public void DecreaseStageIndex()
    {
        StageIndex--;
    }

    public void Roadblocks()
    {
        //roadblock from phase 0 will always be available to appear
        if(Phase0Roadblocks.Count > 0)
        {
            foreach (GameObject Phase0Roadblock in Phase0Roadblocks)
            {
                RoadblocksToAppear.Add(Phase0Roadblock);
                Phase0Roadblocks.Remove(Phase0Roadblock);
            }
        }

        //need to add some gode, not possible until you make the actual gameobjects that will be roadblocks
        if (StageIndex >= 1)
        {
            if (PhaseARoadblocks.Count > 0)
            {
                foreach (GameObject Roadblock_A in PhaseARoadblocks)
                {
                    RoadblocksToAppear.Add(Roadblock_A);
                    PhaseARoadblocks.Remove(Roadblock_A);

                    //set the bool Phase0 of the task to true
                }
            }
        }
        else
        {
            if (PhaseARoadblocks.Count < N_PhaseA)
            {
                //check for tasks that have the Phase 0 bool set to true and do the opposite of the first part of the if statment
            }
        }

        if (StageIndex >= 2)
        {
            if (PhaseBRoadblocks.Count > 0)
            {
                foreach (GameObject Roadblock_B in PhaseBRoadblocks)
                {
                    RoadblocksToAppear.Add(Roadblock_B);
                    PhaseBRoadblocks.Remove(Roadblock_B);
                }
            }
        }
        else
        {
            if (PhaseBRoadblocks.Count < N_PhaseB)
            {
                foreach(GameObject Roadblock in RoadblocksToAppear)
                {

                }
            }
        }

        if (StageIndex >= 3)
        {
            if (PhaseCRoadblocks.Count > 0)
            {
                foreach (GameObject Roadblock_C in PhaseCRoadblocks)
                {
                    RoadblocksToAppear.Add(Roadblock_C);
                    PhaseCRoadblocks.Remove(Roadblock_C);
                }
            }
        }
        else
        {
            if (PhaseCRoadblocks.Count < N_PhaseC)
            {
                
            }
        }

        if (StageIndex >= 4)
        {
            if (PhaseDRoadblocks.Count > 0)
            {
                foreach (GameObject Roadblock_D in PhaseDRoadblocks)
                {
                    RoadblocksToAppear.Add(Roadblock_D);
                    PhaseDRoadblocks.Remove(Roadblock_D);
                }
            }
        }
        else
        {
            if (PhaseDRoadblocks.Count < N_PhaseD)
            {
                
            }
        }
    }
}
