using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharakterAnimation : MonoBehaviour
{
    private Animator anim;

    public string[] staticDirections = { "StaticN", "StaticNW", "StaticW", "StaticSW", "StaticS", "StaticSE", "StaticE", "StaticNE" };
    public string[] runDirections = { "RunN", "RunNW", "RunW", "RunSW", "RunS", "RunSE", "RunE", "RunNE" };

    private float stepCount;

    

    int lastDirection;

    private void Awake()
    {
        anim = GetComponent<Animator>();

        float result1 = Vector2.SignedAngle(Vector2.up, Vector2.right);
        Debug.Log("R1" + result1);

        stepCount = Mathf.FloorToInt(stepCount);
        
    }

    private void Update()
    {
        if (stepCount == 0 && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("attacked N");
        }
    }
    
    public void SetDirection (Vector2 _direction)
    {
        string[] directonArray = null;
       
        
        if(_direction.magnitude < 0.01)
        {
            directonArray = staticDirections;
           
        }
        
        else
        {
            directonArray = runDirections;
           

            lastDirection = DirectionToIndex(_direction);

        }

        anim.Play(directonArray[lastDirection]);
    }
    
    private int DirectionToIndex(Vector2 _direction)
    {
        Vector2 norDir = _direction.normalized;

        float step = 360 / 8;
        float angle = Vector2.SignedAngle(Vector2.up, norDir);
        float offset = step / 2;

        angle += offset;
        if(angle < 0)
        {
            angle += 360;
        }

        float stepCount = angle / step;
        
      
        
        return Mathf.FloorToInt(stepCount);
    
    }

   

}
