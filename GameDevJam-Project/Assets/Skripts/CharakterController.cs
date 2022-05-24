using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharakterController : MonoBehaviour
{
   private Rigidbody2D rb;

    
   [SerializeField] private float moveSpeed = 1.0f;

    
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

      
        
    }

    
    private void FixedUpdate()
    {
      

        //old Movement
        //moveH = Input.GetAxis("Horizontal") * moveSpeed;
        // moveV = Input.GetAxis("Vertical") * moveSpeed;
        // rb.velocity = new Vector2(moveH, moveV);
        // Vector2 direction = new Vector2(moveH, moveV);

       // fixed Movement
        Vector2 currentPos = rb.position;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 inputVector = new(horizontalInput, verticalInput);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);

        Vector2 movement = inputVector * moveSpeed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;

        rb.MovePosition(newPos);

        Vector2 direction = new(horizontalInput, verticalInput);


        //FindObjectOfType<CharakterAnimation>().SetDirection(direction);
        FindObjectOfType<CharakterAnimation>().SetDirection(direction);
    }
  
   
}
