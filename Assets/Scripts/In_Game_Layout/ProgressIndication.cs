using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressIndication : MonoBehaviour
{
    private GameManager AddTo;

    public int Phase0;
    public int PhaseA;
    public int PhaseB;
    public int PhaseC;
    public int PhaseD;

    private void Start()
    {
        AddTo = FindObjectOfType<GameManager>();
    }

    public void Phase0Completed()
    {
        AddTo.progressbarScore = AddTo.progressbarScore + Phase0;
    }
    public void BackToPhase0()
    {
        AddTo.progressbarScore = AddTo.progressbarScore - Phase0;
    }

    public void PhaseACompleted()
    {
        AddTo.progressbarScore = AddTo.progressbarScore + PhaseA;
    }
    public void BackToPhaseA()
    {
        AddTo.progressbarScore = AddTo.progressbarScore - PhaseA;
    }

    public void PhaseBCompleted()
    {
        AddTo.progressbarScore = AddTo.progressbarScore + PhaseB;
    }
    public void BackToPhaseB()
    {
        AddTo.progressbarScore = AddTo.progressbarScore - PhaseB;
    }

    public void PhaseCCompleted()
    {
        AddTo.progressbarScore = AddTo.progressbarScore + PhaseC;
    }
    public void BackToPhaseC()
    {
        AddTo.progressbarScore = AddTo.progressbarScore - PhaseC;
    }

    public void PhaseDCompleted()
    {
        AddTo.progressbarScore = AddTo.progressbarScore + PhaseD;
    }
    public void BackToPhaseD()
    {
        AddTo.progressbarScore = AddTo.progressbarScore - PhaseD;
    }
}
