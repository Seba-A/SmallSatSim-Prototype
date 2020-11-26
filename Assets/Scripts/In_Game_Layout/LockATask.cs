using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockATask : MonoBehaviour
{
    public List<GameObject> Targets;

    // Start is called before the first frame update
    void Start()
    {
        
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
            if (this.GetComponent<TaskTimer>().FirstTimeCompletion)
            {
                Debug.Log(target.transform.name);
            }
            else
            {

            }

            //Debug.Log(target.transform.name);
        }
    }
}
