using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform target;
    private GameObject[] souls;
    public float speed = 5;
    public float stoppingDistance;
    

    void Start() {
        target = GameObject.Find("Player").transform;
        
    }
    //WIP this will change, Coroutine needed here instead.
    void Update() {
        if(GameObject.FindGameObjectsWithTag("Soul") != null)
        {
            souls = GameObject.FindGameObjectsWithTag("Soul");
            foreach (GameObject soul in souls)
            {
            transform.position = Vector3.MoveTowards(transform.position, soul.transform.position, speed * Time.deltaTime);
            Debug.Log("found a Soul");
            }

        }
       if (Vector2.Distance(transform.position,target.position) > stoppingDistance)
       transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
          
        
}
 
}
