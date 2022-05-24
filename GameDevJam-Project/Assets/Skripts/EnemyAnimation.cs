using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator anim;

    int lastDir;


    public string[] staticDirections = { "E_StaticN", "E_StaticNW", "E_StaticW", "E_StaticSW", "E_StaticS", "E_StaticSE", "E_StaticE", "E_StaticNE" };
    public string[] runDirections = { "E_RunN", "E_RunNW", "E_RunW", "E_RunSW", "E_RunS", "E_RunSE", "E_RunE", "E_RunNE" };


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void SetDirection(Vector2 _direction)
    {
        string[] directonArray = null;



        if (_direction.magnitude < 0.1)
        {
            directonArray = staticDirections;

        }

        else
        {
            directonArray = runDirections;


            lastDir = DirectionToIndex(_direction);

        }

        anim.Play(directonArray[lastDir]);
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
