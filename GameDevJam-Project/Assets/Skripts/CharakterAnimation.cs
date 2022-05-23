using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharakterAnimation : MonoBehaviour
{
    private Animator anim;

    public string[] staticDirections = { "StaticN", "StaticNW", "StaticW", "StaticSW", "StaticS", "StaticSE", "StaticE", "StaticNE" };
    public string[] runDirections = { "RunN", "RunNW", "RunW", "RunSW", "RunS", "RunSE", "RunE", "RunNE" };

    public float playerDir;
    private bool attack;

    public Transform attackPoint;
    public Vector2 currentPos;

    int lastDirection;

    private void Awake()
    {
        anim = GetComponent<Animator>();

        float result1 = Vector2.SignedAngle(Vector2.up, Vector2.right);

        attack = false;

       
        
        
    }

    private void Update()
    {
        currentPos = transform.position;

        
        
           if(lastDirection == 0)
           {
               Debug.Log("Attack N");
                attackPoint.position = currentPos + new Vector2(0, 1);
           }

           if (lastDirection == 1)
           {
               Debug.Log("Attack NW");
            attackPoint.position = currentPos + new Vector2(-1, 1);
        }

           if (lastDirection == 2)
           {
               Debug.Log("Attack W");
            attackPoint.position = currentPos + new Vector2(-1, 0);
        }

           if (lastDirection == 3)
           {
               Debug.Log("Attack SW");
            attackPoint.position = currentPos + new Vector2(-1, -1);
        }

           if (lastDirection == 4)
           {
               Debug.Log("Attack S");
            attackPoint.position = currentPos + new Vector2(0, -1);
        }

           if (lastDirection == 5)
           {
               Debug.Log("Attack SE");
            attackPoint.position = currentPos + new Vector2(1, -1);
        }

           if (lastDirection == 6)
           {
               Debug.Log("Attack E");
            attackPoint.position = currentPos + new Vector2(1, 0);
        }

           if (lastDirection == 7)
           {
               Debug.Log("Attack NE");
            attackPoint.position = currentPos + new Vector2(1, 1);
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
