using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharakterController : MonoBehaviour
{
   private Rigidbody2D rb;
   private float moveH, moveV;
   [SerializeField] private float moveSpeed = 1.0f;

    float charDir;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

      
        
    }

    
    private void FixedUpdate()
    {
        FacingDirections();

        moveH = Input.GetAxis("Horizontal") * moveSpeed;
        moveV = Input.GetAxis("Vertical") * moveSpeed;

        rb.velocity = new Vector2(moveH, moveV);

        Vector2 direction = new Vector2(moveH, moveV);

        FindObjectOfType<CharakterAnimation>().SetDirection(direction);
    }
  
    void FacingDirections()
    {
        if(moveV > 0 && moveH == 0) //Norden
        {
            charDir = 0;
            
        }
        
        if(moveV < 0 && moveH == 0) // Süden
        {
            charDir = 4;
        }
        
        if(moveH > 0 && moveV == 0) // Osten
        {
            charDir = 6;
        }
        
        if(moveH < 0 && moveV == 0) // Westen
        {
            charDir = 2;
        }
        
        if(moveV > 0 && moveH >0) //NordOst
        {
            charDir = 7;
        }
        
        if(moveH < 0 && moveV < 0) //SüdWest
        {
            charDir = 3;
        }
        
        if (moveH > 0 && moveV < 0) // SüdOst
        {
            charDir = 5;
        }
        
        if ( moveH < 0 && moveV > 0) //Nordwest
        {
            charDir = 1;
        }
    }
}
