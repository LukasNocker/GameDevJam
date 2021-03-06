using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompAnim : MonoBehaviour
{
   private Animator anim;

    int lastDirection;

    public string[] staticDirections = { "WalkN", "WalkNW", "WalkW", "WalkSW", "WalkS", "WalkSE", "WalkE", "WalkNE" };

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }



    public void SetDirection(Vector2 _direction)
    {
        string[] directonArray = null;



        if (_direction.magnitude < 0.01)
        {
            directonArray = staticDirections;

        }

        else
        {
            directonArray = staticDirections;


            lastDirection = DirectionToIndex(_direction);

        }



        lastDirection = DirectionToIndex(_direction);



        anim.Play(directonArray[lastDirection]);
    }

    private int DirectionToIndex(Vector2 _direction)
    {
        Vector2 norDir = _direction.normalized;

        float step = 360 / 8;
        float angle = Vector2.SignedAngle(Vector2.up, norDir);
        float offset = step / 2;

        angle += offset;
        if (angle < 0)
        {
            angle += 360;
        }

        float stepCount = angle / step;


        return Mathf.FloorToInt(stepCount);

    }
}
