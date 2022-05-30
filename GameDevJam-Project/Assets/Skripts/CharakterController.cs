using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharakterController : MonoBehaviour
{
   private Rigidbody2D rb;
   public static CharakterController instance;

   public string areaTransitionName = "placeholder";

    
   [SerializeField] private float moveSpeed = 1.0f;

    void Start() {
        if(instance == null)
        {
        instance = this;
        }
        else{
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    
    private void FixedUpdate()
    {
        if (!GameObject.Find("DialogBox")) {
        Vector2 currentPos = rb.position;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 inputVector = new(horizontalInput, verticalInput);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);

        Vector2 movement = inputVector * moveSpeed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;

        rb.MovePosition(newPos);

        Vector2 direction = new(horizontalInput, verticalInput);


        FindObjectOfType<CharakterAnimation>().SetDirection(direction);
          FindObjectOfType<CompAnim>().SetDirection(direction);
        }
    }
    
  
   
}
