using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockATask : MonoBehaviour
{
    public Transform parent;
    public List<GameObject> Targets;

    // Start is called before the first frame update
    void Start()
    {
        parent = this.transform.parent;
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
            if (gameObject.GetComponent<TaskTimer>().FirstTimeCompletion)
            {
                (target.GetComponent<Draggable>() as MonoBehaviour).enabled = true;
                Debug.Log(target.transform.name);
            }
            else
            {
                (target.GetComponent<Draggable>() as MonoBehaviour).enabled = false;
            }

            //Debug.Log(target.transform.name);
        }
    }
}
