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

    private float forwardStep = 2f;
    private float forwardDelay = 0.15f;

    public int lives = 3;

    public Vector3 rightPos; 
    public Vector3 leftPos;   

  
    private bool goingLeft = true;
    private bool movingForward = false;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        leftPos = leftPoint.transform.position;
        rightPos = rightPoint.transform.position;

        //Force the initial direction based on starting position
        goingLeft = (transform.position.x > leftPos.x);
    }

    void Update()
    {
        //lock sliding
        Vector3 v = rb.velocity;
        v.x = 0;
        v.z = 0;
        rb.velocity = v;

        Quaternion r = rb.rotation;
        r.x = 0;
        r.z = 0;
        rb.rotation = r;
        MoveBoss();
    }

    private void MoveBoss()
    {
        if (goingLeft)
        {
            if (transform.position.x <= leftPos.x)
            {
                StartCoroutine(MoveForward());
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
                StartCoroutine(MoveForward());
                goingLeft = true;
            }
            else
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
    }

    private IEnumerator MoveForward()
    {
        movingForward = true;

        // optional small pause so it looks less robotic
        //yield return new WaitForSeconds(forwardDelay);

        Vector3 forward = transform.forward * forwardStep;

        float elapsed = 0f;
        float duration = 0.2f;

        Vector3 start = transform.position;
        Vector3 target = start + forward;

        // Smooth forward motion
        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(start, target, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = target;

        movingForward = false;
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
        if (collision.gameObject.tag == "ceilingFan")
        {
            takeDamage();
        }
    }

}
