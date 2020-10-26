using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public void Time_Normal()
    {
        Time.timeScale = 1f;
    }

    public void Time_Two()
    {
        Time.timeScale = 2f;
    }

    public void Time_Three()
    {
        Time.timeScale = 3f;
    }

    public void Time_Four()
    {
        Time.timeScale = 4f;
    }
}
