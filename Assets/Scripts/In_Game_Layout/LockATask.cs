using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockATask : MonoBehaviour
{
    public Transform parentMission;
    public List<GameObject> Targets;

    public bool UnlockTask = false;

    // Start is called before the first frame update
    void Start()
    {
        parentMission = this.transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        CheckFor();
    }

    public void CheckFor()
    {
        foreach(GameObject target in Targets)
        {
            //parentMission.transform.Find(this.transform.name).GetComponent<TaskTimer>().FirstTimeCompletion
            if (gameObject.GetComponent<TaskTimer>().FirstTimeCompletion)
            {
                (target.GetComponent<Draggable>() as MonoBehaviour).enabled = true;
                UnlockTask = true;
                
                Debug.Log(target.transform.name);
            }
            else
            {
                (target.GetComponent<Draggable>() as MonoBehaviour).enabled = false;
            }

            /*
            if (UnlockTask && parentMission.transform.Find(this.transform.name).GetComponent<TaskTimer>().FirstTimeCompletion)
            {
                Debug.Log("We did it");
            }*/
            //Debug.Log(target.transform.name);
        }
    }

    public void ReactivateLockedTasks()
    {
        foreach (GameObject target in Targets)
        {
            (target.GetComponent<Draggable>() as MonoBehaviour).enabled = true;
        }
    }
}
