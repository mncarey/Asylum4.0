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
            LoseALife();
            Respawn();
        }

        GravityFlip();
    }

    public void FixedUpdate()//called in fixed intervals at the same rate as the physics system - 50 rates per frame
    {
        PlayerMove();
    }

    public void LoseALife()
    {
        lives--;
        if (lives > 0)
        {
            Debug.Log("Lives = " + lives);
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    
    }
    /// <summary>
    /// This will bring the player back to the statPos and lose a life
    /// </summary>
    /// 
    private void Respawn()
    {
        transform.position = currentCheckpoint;
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
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;
        camForward.y = 0;
        camRight.y = 0;

        camForward.Normalize();
        camRight.Normalize();

        //moveDirection will change based on camera direction
        Vector3 moveDirection = (camForward * vertical + camRight * horizontal).normalized;

        //Normalize the movement direction if there is any input
        if (moveDirection.magnitude > 0)
        {
            moveDirection.Normalize();

            
            //Rotate player to face movement direction
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);

            RaycastHit hit;

            if (Physics.Raycast(transform.position, Vector3.up, out hit, 1.5f)){//player is on ceiling
                Quaternion flipRotation = Quaternion.Euler(180f, 180f, 0f);//rotate the player downwards
                targetRotation *= flipRotation;
            }

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);//rotate the player upwards

             //Apply movement
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

        if (other.gameObject.tag == "Obstacle")
        {
            LoseALife();
            Respawn();
        }

        if (other.gameObject.tag == "Fire")
        {
            LoseALife();
            Respawn();
        }

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
                //labKeys -= collision.transform.GetComponent<Door>().Locks;
                collision.gameObject.SetActive(false);
                Debug.Log("Unlocked Lab Door");
                labKeys = 0;
                Debug.Log("Keys left: " + labKeys);
            }
            else
            {
                if (labKeys < collision.transform.GetComponent<Door>().Locks)
                {
                    int missingLabKeys = collision.transform.GetComponent<Door>().Locks - labKeys;
                    Debug.Log("need " + missingLabKeys + " more lab key(s)");
                }
            }
            
        }
        if (collision.gameObject.tag == "Room2EntranceDoor")
        {
            if (labKeys >= collision.transform.GetComponent<Door>().Locks)
            {
                //labKeys -= collision.transform.GetComponent<Door>().Locks;
                collision.gameObject.SetActive(false);
                Debug.Log("Unlocked Lab Door");
                labKeys = 0;
            }
            else
            {
                if (labKeys < collision.transform.GetComponent<Door>().Locks)
                {
                    int missingLabKeys = collision.transform.GetComponent<Door>().Locks - labKeys;
                    Debug.Log("need " + missingLabKeys + " more lab key(s)");
                }
            }
         
        }
        if (collision.gameObject.tag == "Room2ExitDoor")
        {
            if (labKeys >= collision.transform.GetComponent<Door>().Locks)
            {
                labKeys -= collision.transform.GetComponent<Door>().Locks;
                collision.gameObject.SetActive(false);
                Debug.Log("Unlocked Lab Door");
                labKeys = 0;
            }
            else
            {
                if (labKeys < collision.transform.GetComponent<Door>().Locks)
                {
                    int missingLabKeys = collision.transform.GetComponent<Door>().Locks - labKeys;
                    Debug.Log("need " + missingLabKeys + " more lab key(s)");
                }
            }
        }
    }

}
