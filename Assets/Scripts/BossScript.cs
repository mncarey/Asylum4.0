using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class BossSprint : MonoBehaviour
{
    public float speed = 1.5f;

    private Vector3 pointA;
    private Vector3 pointB;

    private float time = 0f;
    private bool isAtPointA = true;

    void Start()
    {
        Vector3 start = transform.position;

        pointA = start + new Vector3(
            Random.Range(-10f, 10f),
            Random.Range(-2f, 2f),
            Random.Range(-5f, 5f)
        );

        pointB = start + new Vector3(
            Random.Range(-10f, 10f),
            Random.Range(-2f, 2f),
            Random.Range(-5f, 5f)
        );
    }

    private void Update()
    {
        time = time + speed * Time.deltaTime;

        if (isAtPointA)
        {
            transform.position = Vector3.Lerp(pointA, pointB, time);

            if (time >= 1f) //time = 1 is the end, where 0 is the beginning. Lerp uses time.
            {
                pointA = pointB;//old point becomes new point

                pointB = pointA + GetRandomPoint();

                time = 0f;

                isAtPointA = true;//trying to go torward new B
            }
        }

    }

    private Vector3 GetRandomPoint()
    {
        return new Vector3(
            Random.Range(-10f, 10f),
            Random.Range(-2f, 2f),
            Random.Range(-5f, 5f));
    }
    
}
