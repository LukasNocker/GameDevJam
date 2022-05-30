using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion : MonoBehaviour
{
    // Start is called before the first frame update
    public static Companion instance;

    private Transform target;
    private GameObject[] souls;
    public float speed = 5;
    public float stoppingDistance;
    private bool soulExists;

    private Vector3 moveDelta;
    private Vector2 movex;
    private Vector2 movey;

    void Start() {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        target = GameObject.Find("Player").transform;
        souls = new GameObject[]{};
        
    }
    //WIP this will change, Coroutine needed here instead.
    void Update() {

        if ((souls.Length == 0) || (!souls[0])){
            
        if(GameObject.FindGameObjectsWithTag("Soul") != null)
        {
            souls = GameObject.FindGameObjectsWithTag("Soul");
        }
            
        }
        if (souls.Length != 0)
        {
            CollectSoul(souls);
        }
        else {
        if(Vector2.Distance(transform.position,target.position) > stoppingDistance)
        {
       transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
          }}



        moveDelta = new Vector3(transform.position.x * speed, transform.position.y * speed, 0);
        Vector2 compDir = new(moveDelta.x, moveDelta.y);
        //FindObjectOfType<CompAnim>().SetDirection(compDir);

    }
    void CollectSoul(GameObject[] souls)
    {
         transform.position = Vector3.MoveTowards(transform.position, souls[0].transform.position, speed * Time.deltaTime);
         Debug.Log("found a Soul");
         
    }

   
}


