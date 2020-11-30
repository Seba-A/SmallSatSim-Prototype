using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMissionScore : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        gameManager.redundancyScore = 0;
        gameManager.reliabilityScore = 0;
        gameManager.clarityScore = 0;
        gameManager.efficiencyScore = 0;
        gameManager.innovationScore = 0;
    }
}
