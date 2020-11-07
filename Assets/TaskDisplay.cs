using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskDisplay : MonoBehaviour
{
    public Task task;

    public TextMeshProUGUI nameTask;
    public TextMeshProUGUI descriptionText;
    
    // Start is called before the first frame update
    void Start()
    {
        nameTask.text = task.name;
        descriptionText.text = task.description;
    }
}
