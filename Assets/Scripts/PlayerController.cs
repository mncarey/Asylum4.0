using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author: [Carey, Madison]
 * Date Created: [10/17/2024]
 * Last Updated: [10/26/2024]
 * [This will handle movement and collision for the player.]
 */


public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    private Rigidbody rigidBody;
    public int moveSpeed;
    public int coinCount;
    public int lives;
    private Vector3 startPos;
    public float stunTimer;



    // Start is called before the first frame update
    void Start()
    {
        //set the reference to the rigidBody thats attached to the player
        rigidBody = GetComponent<Rigidbody>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerJump();
        if (transform.position.y < -15)//if the player falls off platform
        {
            Respawn();
        }
    }

    public void FixedUpdate()//called in fixed intervals at the same rate as the physics system - 50 rates per frame
    {
        PlayerMove();
        CheckAbove();
        CheckBelow();
    }

    /// <summary>
    /// This will bring the player back to the statPos and lose a life
    /// </summary>
    private void Respawn()
    {
        lives--;
        transform.position = startPos;

        if (lives == 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    /// <summary>
    /// Player will jump by adding force when space is pressed
    /// </summary>
    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit;

            //if raycast returns that it hit something, that means the player is touching the ground
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f))
            {
                Debug.Log("Touching the ground.");
                rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //impulse gives it velocity as the player jumps upwards with some force
            }
            else
            {
                Debug.Log("The player is not touching the ground.");
            }


        }
    }

    /// <summary>
    /// The player will move using a and d keys to move left or right
    /// </summary>
    private void PlayerMove()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            rigidBody.MovePosition(transform.position + Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            rigidBody.MovePosition(transform.position + Vector3.right * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            rigidBody.MovePosition(transform.position + Vector3.back * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            //transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            rigidBody.MovePosition(transform.position + Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }

    /// <summary>
    /// Detects collision using a trigger event
    /// </summary>
    /// <param name="other"> the other object the playeer is colliding with that is triggered</param>
    private void OnTriggerEnter(Collider other)
    {
        /*
        if (other.gameObject.tag == "Coin")
        {
            other.gameObject.SetActive(false);
            coinCount++;
        }
        if (other.gameObject.tag == "Enemy")
        {
            Respawn();
        }
        if (other.gameObject.tag == "Laser")
        {
            StartCoroutine(Stun());
        }
        if (other.gameObject.tag == "Obstacle")
        {
            Respawn();
        }
        if (other.gameObject.tag == "Portal")
        {
            //reset the start pos to the spawn point pos
            startPos = other.gameObject.GetComponent<Portal>().spawnPoint1.transform.position;

            //bring the player
            transform.position = startPos;
        }
        if (other.gameObject.tag == "Portal 2")
        {
            startPos = other.gameObject.GetComponent<Portal>().spawnPoint2.transform.position;
            transform.position = startPos;
        }
        */
    }

    /// <summary>
    /// Check above the player using a raycast
    /// </summary>
    private void CheckAbove()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.up, out hit, 1f))// <- position of player, shoot raycast upward, use output of raycast, how far we shoot the raycast
        {
            if (hit.collider.gameObject.tag == "Thwomp")
            {
                Respawn();
            }
        }
    }

    /// <summary>
    /// Check below the player using a raycast
    /// </summary>
    private void CheckBelow()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f))
        {
            if (hit.collider.gameObject.tag == "Flying Koopa")
            {
                Debug.Log("Hit flying koopa");
                Destroy(hit.collider.gameObject);
            }
        }
    }

    /// <summary>
    /// Stuns player after getting hit with laser
    /// </summary>
    /// <returns></returns>
    IEnumerator Stun()
    {
        int currentPlayerSpeed = moveSpeed;
        moveSpeed = 0;
        yield return new WaitForSeconds(stunTimer);
        moveSpeed = currentPlayerSpeed;

    }
}
