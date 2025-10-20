using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

/*
 * Author: [Carey, Madison], [Barajas, Daniela]
 * Date Created: [10/02/2025]
 * Last Updated: [10/15/2025]
 * [This will handle movement and collision for the player.]
 */


public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    private Rigidbody rigidBody;
    public int moveSpeed;
    public int coinCount;
    public int lives;
    public Object spawnPoint;
    private Vector3 startPos;
    private Vector3 currentCheckpoint;
    public float stunTimer;
    private bool isGravityFlipped = false;
    private Vector3 originalGravity;

    public int labKeys = 0;



    // Start is called before the first frame update
    void Start()
    {
        //set the reference to the rigidBody thats attached to the player
        rigidBody = GetComponent<Rigidbody>();
        //startPos = spawnPoint;
        originalGravity = Physics.gravity;
        currentCheckpoint = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerJump();
        if (transform.position.y < -15)//if the player falls off platform
        {
            Respawn();
        }

        GravityFlip();
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
        transform.position = currentCheckpoint;

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

    private void GravityFlip()
    {
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                RaycastHit hit;

                //if raycast returns that it hit something, that means the player is touching the ground
                if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f))
                {
                    Debug.Log("Touching the ground.");
                    isGravityFlipped = !isGravityFlipped;
                    //pressing f inverts gravity
                    if (isGravityFlipped)
                    {
                        Physics.gravity = -originalGravity;
                    }
                    else
                    {
                        Physics.gravity = originalGravity;
                    }

                    transform.Rotate(0, 0, 180);//rotate player to be upright //impulse gives it velocity as the player jumps upwards with some force
                }
                if (Physics.Raycast(transform.position, Vector3.up, out hit, 1f))
                {
                    Debug.Log("Touching the ceiling.");
                    isGravityFlipped = !isGravityFlipped;
                    //pressing f inverts gravity
                    if (isGravityFlipped)
                    {
                        Physics.gravity = -originalGravity;
                    }
                    else
                    {
                        Physics.gravity = originalGravity;
                    }

                    transform.Rotate(0, 0, 180);//rotate player to be upright //impulse gives it velocity as the player jumps upwards with some force
                }
                else
                {
                    Debug.Log("The player is not touching the ground.");
                }


            }
        }
    }

    /// <summary>
    /// The player will move using a and d keys to move left or right
    /// </summary>
    private void PlayerMove()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            moveDirection += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += Vector3.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection += Vector3.back;
        }
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += Vector3.forward;
        }

        // Normalize the movement direction if there is any input
        if (moveDirection != Vector3.zero)
        {
            moveDirection.Normalize();

            // Handle rotation based on gravity flip
            Quaternion targetRotation;
            if (isGravityFlipped == true)
            {
                // If gravity is flipped, the character should appear to be upside down,
                // so we rotate to face the direction and then rotate 180 degrees around Z axis.
                targetRotation = Quaternion.LookRotation(moveDirection) * Quaternion.Euler(0, 0, 180);
            }
            else
            {
                targetRotation = Quaternion.LookRotation(moveDirection);
            }

            transform.rotation = targetRotation;

            // Apply movement
            rigidBody.MovePosition(rigidBody.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
        }
    }

    /// <summary>
    /// Detects collision using a trigger event
    /// </summary>
    /// <param name="other"> the other object the playeer is colliding with that is triggered</param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "LabKey")
        {
            Debug.Log("Collected lab Key");
            labKeys++;
            other.gameObject.SetActive(false);

        }

        if(other.gameObject.tag == "Checkpoint")
        {
            currentCheckpoint = other.transform.position;
            Debug.Log("Checkpoint reached at: " + currentCheckpoint);
        }
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
    /// This function handles collision events for the doors.
    /// </summary>
    /// <param name="collision">The collision that is being returned.</param>

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Room1ExitDoor")
        {
            if (labKeys >= collision.transform.GetComponent<Door>().Locks)
            {
                labKeys -= collision.transform.GetComponent<Door>().Locks;
                collision.gameObject.SetActive(false);
                Debug.Log("Unlocked Lab Door");
            }
            else
            {
                if (labKeys < collision.transform.GetComponent<Door>().Locks)
                {
                    int missingLabKeys = collision.transform.GetComponent<Door>().Locks - labKeys;
                    Debug.Log("need " + missingLabKeys + " more lab key(s)");
                }
            }
            labKeys = 0;
        }
        if (collision.gameObject.tag == "Room2EntranceDoor")
        {
            if (labKeys >= collision.transform.GetComponent<Door>().Locks)
            {
                labKeys -= collision.transform.GetComponent<Door>().Locks;
                collision.gameObject.SetActive(false);
                Debug.Log("Unlocked Lab Door");
            }
            else
            {
                if (labKeys < collision.transform.GetComponent<Door>().Locks)
                {
                    int missingLabKeys = collision.transform.GetComponent<Door>().Locks - labKeys;
                    Debug.Log("need " + missingLabKeys + " more lab key(s)");
                }
            }
            labKeys = 0;
        }
        if (collision.gameObject.tag == "Room2ExitDoor")
        {
            if (labKeys >= collision.transform.GetComponent<Door>().Locks)
            {
                labKeys -= collision.transform.GetComponent<Door>().Locks;
                collision.gameObject.SetActive(false);
                Debug.Log("Unlocked Lab Door");
            }
            else
            {
                if (labKeys < collision.transform.GetComponent<Door>().Locks)
                {
                    int missingLabKeys = collision.transform.GetComponent<Door>().Locks - labKeys;
                    Debug.Log("need " + missingLabKeys + " more lab key(s)");
                }
            }
            labKeys = 0;
        }
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
