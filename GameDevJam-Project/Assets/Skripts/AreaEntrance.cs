using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{

    public string transitionName;
    // Start is called before the first frame update
    void Start()
    {
        if (CharakterController.instance.areaTransitionName != null) {
        if (transitionName == CharakterController.instance.areaTransitionName)
        {
            CharakterController.instance.transform.position = transform.position;
        }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
