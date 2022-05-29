using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Object : MonoBehaviour
{   
   

    //Public Fields
 
    public float pushRecoverySpeed = 0.2f;
    [SerializeField]
    private float attackSpeed = 1f;
    private float canAttack = 1f;
    public float attackRange = 2f;
    private GameObject dialogBox;

    //Immunity
    protected float immuneTime = 1.0f;
    protected float lastImmune;

    //Moving fields
    protected CapsuleCollider2D capsuleCollider;
    protected Vector3 moveDelta;
    protected RaycastHit2D hit;
    protected float ySpeed = 0.75f;
    protected float xSpeed = 1.0f;

    //Souls
    public int soulsValue = 1;
    public GameObject SoulCollectable;
    
    //Logic
    public float triggerLength = 10;
    public float chaseLength = 15;
    private bool chasing;
    private bool collidingWithPlayer;
    private Transform playerTransform;
    private Vector3 startingPosition;

    //Hitbox
    public ContactFilter2D filter;
    private CapsuleCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];

    // Damage
    public float damage = 1;
    public float pushForce = 5;

    //push
    protected Vector3 pushDirection;

    //start
    protected virtual void Start()
    {
            capsuleCollider = GetComponent<CapsuleCollider2D>();
            playerTransform = GameObject.Find("Player").transform;
            startingPosition = transform.position;
            
        // if (this.gameObject.transform.childCount > 0)
        // {
        //     hitbox = transform.GetChild(0).GetComponent<CapsuleCollider2D>();
            
        // }
    }

    

    //Enemy Moving

    protected virtual void UpdateMotor(Vector3 input)
    {
        

        // Reset MoveDelta
        moveDelta = new Vector3(input.x * xSpeed, input.y * ySpeed, 0);

      

        //add push vector, if any
        moveDelta += pushDirection;

        //reduc epush force every frame, based off recovery speed

        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);

        // Make sure we can move in this direction, by casting a box tehre first, if the box returns null, we're free to move
        hit = Physics2D.BoxCast(transform.position, capsuleCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Players", "Blocking"));
        if (hit.collider == null)

        {

            // make this thing move!
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);

        }
        // Make sure we can move in this direction, by casting a box tehre first, if the box returns null, we're free to move
        hit = Physics2D.BoxCast(transform.position, capsuleCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Players", "Blocking"));
        if (hit.collider == null)

        {

            // make this thing move!
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);

        }

    }

    //Chasing Mechanic
    private void FixedUpdate()
    {
       

        //is the player in range?
        if (Vector3.Distance(playerTransform.position, startingPosition) < chaseLength)
        {
            if (Vector3.Distance(playerTransform.position, startingPosition) < triggerLength)

                chasing = true;


            if (chasing)
            {
                if (!collidingWithPlayer)
                {
                    UpdateMotor((playerTransform.position - transform.position).normalized);
                }
            }
            else
            {
                UpdateMotor(startingPosition - transform.position);
            }
        }
        else
        {
            UpdateMotor(startingPosition - transform.position);
            chasing = false;
        }

        // Check for Overlaps
        collidingWithPlayer = false;
        capsuleCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;


            if (hits[i].tag == "Player" && hits[i].name == "Player")
            {
                collidingWithPlayer = true;
            }

            //the array is not cleaned up, so we do it ourself
            hits[i] = null;
        }

        Vector2 movedir = new(moveDelta.x, moveDelta.y);
//        FindObjectOfType<EnemyAnimation>().SetDirection(movedir);
        if(Vector2.Distance(transform.position,playerTransform.position) < attackRange)
        {
            if (attackSpeed <= canAttack){
                HealthSystem healthSystem = GameObject.Find("Player").GetComponent<HealthSystem>();
                healthSystem.Damage(damage);
                if (GameObject.Find("DialogBox"))
                {
                    dialogBox = GameObject.Find("DialogBox");
                    dialogBox.SetActive(false);
                }
                canAttack = 0f;
                Debug.Log("You received damage: " + damage);
                }
                else {
                canAttack += Time.deltaTime;
                }
        }

    }

    protected virtual void Death()
    {
        Destroy(transform.root.gameObject);
        Instantiate(SoulCollectable, transform.position, Quaternion.identity);
        Debug.Log("enemy died");
    }
}
