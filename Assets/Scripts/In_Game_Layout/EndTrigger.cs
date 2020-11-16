using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject progressbar;

    // Update is called once per frame
    void Update()
    {
        if (progressbar.GetComponent<ProgressBar>().current == progressbar.GetComponent<ProgressBar>().maximum ||
            progressbar.GetComponent<ProgressBar>().current > progressbar.GetComponent<ProgressBar>().maximum)
        {
            gameManager.CompleteLevel();
        }
    }

    //gameManager.CompleteLevel();
}
