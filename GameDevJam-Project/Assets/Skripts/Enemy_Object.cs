using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Object : MonoBehaviour
{
   

    //Public Fields
    public int currentHealth;
    public int experience = 10;
    public int maxHealth = 10;
    public float pushRecoverySpeed = 0.2f;

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
    public int damage = 1;
    public float pushForce = 5;

    //push
    protected Vector3 pushDirection;

    //start
    protected virtual void Start()
    {
            capsuleCollider = GetComponent<CapsuleCollider2D>();
            playerTransform = GameObject.Find("Player").transform;
            startingPosition = transform.position;
            currentHealth = maxHealth;
        if (this.gameObject.transform.childCount > 0)
        {
            hitbox = transform.GetChild(0).GetComponent<CapsuleCollider2D>();
            
        }
    }

    

    //Enemy Moving

    protected virtual void UpdateMotor(Vector3 input)
    {
        // Reset MoveDelta
        moveDelta = new Vector3(input.x * xSpeed, input.y * ySpeed, 0);

        //Swap Sprite direction, wehter you're going right or left
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

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
    }
    // All Enemies can receive damage / die
    // protected virtual void ReceiveDamage(Damage dmg)
    // {
    //     if (Time.time - lastImmune > immuneTime)
    //     {
    //         lastImmune = Time.time;
    //         currentHealth -= damage;
    //         pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

    //         GameManager.instance.ShowText(dmg.damageAmount.ToString(), 25, Color.red, transform.position, Vector3.up * 25, 0.5f);
    //         Debug.Log("new hitpoints:" + currentHealth + " left");

    //         if (currentHealth <= 0)
    //         {
             
    //             Death();
    //         }
    //     }
    // }

    //Deal Damage
    protected void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Player")
        {

            if (coll.name == "Player")
            {
                //Create a new Damage Object, then we'll send it to the fighter we've hit
                Damage dmg = new Damage
                {
                    damageAmount = damage,
                    origin = transform.position,
                    pushForce = pushForce,
                };

                coll.SendMessage("ReceiveDamage", dmg);

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
