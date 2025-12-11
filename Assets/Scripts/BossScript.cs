using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossSprint : MonoBehaviour
{
    public float speed = 1.5f;

    public GameObject leftPoint;
    public GameObject rightPoint;

    private float forwardStep = 2f;
    private float forwardDelay = 0.15f;

    public int lives = 10;

    public Vector3 rightPos; 
    public Vector3 leftPos;   

  
    private bool goingLeft = true;
    private bool movingForward = false;

    private Rigidbody rb;


    //health
    public GameObject Health1;
    public GameObject Health2;
    public GameObject Health3;
    public GameObject Health4;
    public GameObject Health5;
    public GameObject Health6;
    public GameObject Health7;
    public GameObject Health8;
    public GameObject Health9;
    public GameObject Health10;


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
        switch (lives)
        {
            case 0:
                {
                    Health1.gameObject.SetActive(false);
                    Health2.gameObject.SetActive(false);
                    Health3.gameObject.SetActive(false);
                    Health4.gameObject.SetActive(false);
                    Health5.gameObject.SetActive(false);
                    Health6.gameObject.SetActive(false);
                    Health6.gameObject.SetActive(false);
                    Health7.gameObject.SetActive(false);
                    Health8.gameObject.SetActive(false);
                    Health9.gameObject.SetActive(false);
                    Health10.gameObject.SetActive(false);
                    break;
                }
            case 1:
                {
                    Health1.gameObject.SetActive(true);
                    Health2.gameObject.SetActive(false);
                    Health3.gameObject.SetActive(false);
                    Health4.gameObject.SetActive(false);
                    Health5.gameObject.SetActive(false);
                    Health6.gameObject.SetActive(false);
                    Health6.gameObject.SetActive(false);
                    Health7.gameObject.SetActive(false);
                    Health8.gameObject.SetActive(false);
                    Health9.gameObject.SetActive(false);
                    Health10.gameObject.SetActive(false);
                    break;
                }
            case 2:
                {
                    Health1.gameObject.SetActive(true);
                    Health2.gameObject.SetActive(true);
                    Health3.gameObject.SetActive(false);
                    Health4.gameObject.SetActive(false);
                    Health5.gameObject.SetActive(false);
                    Health6.gameObject.SetActive(false);
                    Health6.gameObject.SetActive(false);
                    Health7.gameObject.SetActive(false);
                    Health8.gameObject.SetActive(false);
                    Health9.gameObject.SetActive(false);
                    Health10.gameObject.SetActive(false);
                    break;
                }
            case 3:
                {
                    Health1.gameObject.SetActive(true);
                    Health2.gameObject.SetActive(true);
                    Health3.gameObject.SetActive(true);
                    Health4.gameObject.SetActive(false);
                    Health5.gameObject.SetActive(false);
                    Health6.gameObject.SetActive(false);
                    Health6.gameObject.SetActive(false);
                    Health7.gameObject.SetActive(false);
                    Health8.gameObject.SetActive(false);
                    Health9.gameObject.SetActive(false);
                    Health10.gameObject.SetActive(false);
                    break;
                }
            case 4:
                {
                    Health1.gameObject.SetActive(true);
                    Health2.gameObject.SetActive(true);
                    Health3.gameObject.SetActive(true);
                    Health4.gameObject.SetActive(true);
                    Health5.gameObject.SetActive(false);
                    Health6.gameObject.SetActive(false);
                    Health6.gameObject.SetActive(false);
                    Health7.gameObject.SetActive(false);
                    Health8.gameObject.SetActive(false);
                    Health9.gameObject.SetActive(false);
                    Health10.gameObject.SetActive(false);
                    break;
                }
            case 5:
                {
                    Health1.gameObject.SetActive(true);
                    Health2.gameObject.SetActive(true);
                    Health3.gameObject.SetActive(true);
                    Health4.gameObject.SetActive(true);
                    Health5.gameObject.SetActive(true);
                    Health6.gameObject.SetActive(false);
                    Health6.gameObject.SetActive(false);
                    Health7.gameObject.SetActive(false);
                    Health8.gameObject.SetActive(false);
                    Health9.gameObject.SetActive(false);
                    Health10.gameObject.SetActive(false);
                    break;
                }
            case 6:
                {
                    Health1.gameObject.SetActive(true);
                    Health2.gameObject.SetActive(true);
                    Health3.gameObject.SetActive(true);
                    Health4.gameObject.SetActive(true);
                    Health5.gameObject.SetActive(true);
                    Health6.gameObject.SetActive(true);
                    Health6.gameObject.SetActive(false);
                    Health7.gameObject.SetActive(false);
                    Health8.gameObject.SetActive(false);
                    Health9.gameObject.SetActive(false);
                    Health10.gameObject.SetActive(false);
                    break;
                }
            case 7:
                {
                    Health1.gameObject.SetActive(true);
                    Health2.gameObject.SetActive(true);
                    Health3.gameObject.SetActive(true);
                    Health4.gameObject.SetActive(true);
                    Health5.gameObject.SetActive(true);
                    Health6.gameObject.SetActive(true);
                    Health6.gameObject.SetActive(true);
                    Health7.gameObject.SetActive(false);
                    Health8.gameObject.SetActive(false);
                    Health9.gameObject.SetActive(false);
                    Health10.gameObject.SetActive(false);
                    break;
                }
            case 8:
                {
                    Health1.gameObject.SetActive(true);
                    Health2.gameObject.SetActive(true);
                    Health3.gameObject.SetActive(true);
                    Health4.gameObject.SetActive(true);
                    Health5.gameObject.SetActive(true);
                    Health6.gameObject.SetActive(true);
                    Health7.gameObject.SetActive(true);
                    Health8.gameObject.SetActive(true);
                    Health9.gameObject.SetActive(false);
                    Health10.gameObject.SetActive(false);
                    break;
                }
            case 9:
                {
                    Health1.gameObject.SetActive(true);
                    Health2.gameObject.SetActive(true);
                    Health3.gameObject.SetActive(true);
                    Health4.gameObject.SetActive(true);
                    Health5.gameObject.SetActive(true);
                    Health6.gameObject.SetActive(true);
                    Health6.gameObject.SetActive(true);
                    Health7.gameObject.SetActive(true);
                    Health8.gameObject.SetActive(true);
                    Health9.gameObject.SetActive(true);
                    Health10.gameObject.SetActive(false);
                    break;
                }
            case 10:
                {
                    Health1.gameObject.SetActive(true);
                    Health2.gameObject.SetActive(true);
                    Health3.gameObject.SetActive(true);
                    Health4.gameObject.SetActive(true);
                    Health5.gameObject.SetActive(true);
                    Health6.gameObject.SetActive(true);
                    Health6.gameObject.SetActive(true);
                    Health7.gameObject.SetActive(true);
                    Health8.gameObject.SetActive(true);
                    Health9.gameObject.SetActive(true);
                    Health10.gameObject.SetActive(true);
                    break;
                }
        }

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
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(6);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "flippableObejct")
        {
            takeDamage();
        }
        if (collision.gameObject.tag == "CeilingFan")
        {
            takeDamage();
        }
    }

}
