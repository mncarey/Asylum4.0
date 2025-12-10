using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class BossSprint : MonoBehaviour
{
    public float speed = 1.5f;

    public GameObject leftPoint;
    public GameObject rightPoint;

    public int lives = 3;

    public Vector3 rightPos; 
    public Vector3 leftPos;   

    private float t = 0f;
    private bool goingLeft = true;

    void Start()
    {
        leftPos = leftPoint.transform.position;
        rightPos = rightPoint.transform.position;

        // Force the initial direction based on starting position
        goingLeft = (transform.position.x > leftPos.x);
    }

    void Update()
    {
        MoveBoss();
    }

    private void MoveBoss()
    {
        if (goingLeft)
        {
            if (transform.position.x <= leftPos.x)
            {
                goingLeft = false;
            }
            else
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }
        else
        {
            if (transform.position.x >= rightPos.x)
            {
                goingLeft = true;
            }
            else
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
    }

    private void takeDamage()
    {
        lives--;
        if (lives <= 0)
        {
            Debug.Log("enemy damage");
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "flippableObejct")
        {
            takeDamage();
        }
    }

}
