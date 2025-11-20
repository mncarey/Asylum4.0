using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

/*
 * Author: [Carey, Madison], [Barajas, Daniela] [Martinez, Nick]
 * Date Created: [10/02/2025]
 * Last Updated: [10/21/2025]
 * [This will handle movement and collision for the player.]
 */


public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    private Rigidbody rigidBody;
    public int moveSpeed;

    private bool isOnButton;
    public int coinCount;
    public int lives;
    public Object spawnPoint;
    private Vector3 startPos;
    private Vector3 currentCheckpoint;
    public float stunTimer;
    public bool isGravityFlipped = false;
    public Vector3 originalGravity;

    public int labKeys = 0;
    public GameObject FloatingTextPrefab;
    public ButtonLaserSpawner laserScriptReference;
    public bool lasersVisible = false;

    private StringVariables stringVars;
    public int movementSpeed = 25;

    public LayerMask groundLayer;
    bool isNearObject = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
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
        if(transform.position.y > 60)
        {

            Physics.gravity = originalGravity;
            LoseALife();
            Respawn();

        }

       GravityFlip();
       laserTrigger();
        flipObject();

        
    }

    public void FixedUpdate()//called in fixed intervals at the same rate as the physics system - 50 rates per frame
    {
        PlayerMove();

        Vector3 v = rigidBody.velocity;

        // Lock sideways drift so player does NOT push objects
        v.x = 0f;
        v.z = 0f;

        rigidBody.velocity = v;
    }

    public bool flipObject()
    {
        if(isNearObject)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void laserTrigger()
    {
        if (isOnButton && Input.GetKeyDown(KeyCode.E))
        {
            laserScriptReference.killTheLasers =! laserScriptReference.killTheLasers;

        }
    }

    //Function to draw sphere check gizmos
    void OnDrawGizmosSelected()
    {
        // Only run if the game is playing (so Physics works properly)
        if (!Application.isPlaying) return;

        float checkOffset = 0.55f; // distance from center
        float checkRadius = 0.5f; // radius of the sphere

        // Perform the same checks used in GravityFlip()
        bool isGrounded = Physics.CheckSphere(transform.position - Vector3.up * checkOffset, checkRadius, groundLayer);
        bool isCeilinged = Physics.CheckSphere(transform.position + Vector3.up * checkOffset, checkRadius, groundLayer);

        // Determine if gravity can flip
        bool canFlip = isGrounded || isCeilinged;

        // Color based on state
        Gizmos.color = canFlip ? Color.green : Color.red;

        // Draw both spheres (green = can flip, red = cannot flip)
        Gizmos.DrawWireSphere(transform.position - Vector3.up * checkOffset, checkRadius);
        Gizmos.DrawWireSphere(transform.position + Vector3.up * checkOffset, checkRadius);
    }

    private void GravityFlip()
    {
        //checking player position
        bool isOnGround = Physics.CheckSphere(transform.position - Vector3.up * 0.55f, 0.5f, groundLayer);
        bool isOnCeiling = Physics.CheckSphere(transform.position + Vector3.up * 0.55f, 0.5f, groundLayer);

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isOnGround || isOnCeiling)
            {
                isGravityFlipped = !isGravityFlipped;//change to opposite

                if (isGravityFlipped)
                {
                    Physics.gravity = -originalGravity;//if og gravity, flip it
                }
                else
                {
                    Physics.gravity = originalGravity;//if its already flipped, reset it
                }
            }
            else Debug.Log("nah");
        }
        
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
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(2);
        }
    
    }
    /// <summary>
    /// This will bring the player back to the statPos and lose a life
    /// </summary>
    /// 
    public void Respawn()
    {

        Physics.gravity = originalGravity;
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

    /*
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
                    Debug.DrawRay(transform.position, Vector3.down * 1f, Color.red);
                   
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

                    //transform.Rotate(0, 0, 180);//rotate player to be upright //impulse gives it velocity as the player jumps upwards with some force
                }
                if (Physics.Raycast(transform.position, Vector3.up, out hit, 1f))
                {
                    Debug.DrawRay(transform.position, Vector3.up * 1f, Color.blue);
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

                    //transform.Rotate(0, 0, 180);//rotate player to be upright //impulse gives it velocity as the player jumps upwards with some force
                }
                else
                {
                    //Debug.Log("The player is not touching the ground.");
                }


            }
        }
    }
    */

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
            // Base speed
            float currentSpeed = moveSpeed;

            // Check for sprint input (hold Left Shift)
            if (Input.GetKey(KeyCode.LeftShift))
            {
                currentSpeed *= 1.8f; // Sprint multiplier (you can tweak this)
            }

            //Rotate player to face movement direction
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);

            RaycastHit hit;

            if (Physics.Raycast(transform.position, Vector3.up, out hit, 1.5f))
            {
                //player is on ceiling
                Quaternion flipRotation = Quaternion.Euler(180f, 180f, 0f);//rotate the player downwards
                targetRotation *= flipRotation;
            }

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);

            // Apply movement
            rigidBody.MovePosition(rigidBody.position + moveDirection * currentSpeed * Time.fixedDeltaTime);
        }
    }

    /// <summary>
    /// Detects collision using a trigger event
    /// </summary>
    /// <param name="other"> the other object the player is colliding with that is triggered</param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "LabKey")
        {
            Debug.Log("Collected lab Key");
            labKeys++;

            string message = StringVariables.addedKey;

            //show floating text
            FloatingText.ShowFloatingText(FloatingTextPrefab, other.transform.position, message);

            other.gameObject.SetActive(false);

        }

        if(other.gameObject.tag == "Checkpoint")
        {
            currentCheckpoint = other.transform.position;
            Debug.Log("Checkpoint reached at: " + currentCheckpoint);

            string message = StringVariables.checkpoint;

            //show floating text
            FloatingText.ShowFloatingText(FloatingTextPrefab, other.transform.position, message);
        }

        //the followinf 2 are for the Laser Hallways
        if(other.gameObject.tag == "TurnOffLasers")
        {
            lasersVisible = false;
            Debug.Log("turning off lasers");
        }

        if (other.gameObject.tag == "TurnOnLasers")
        {
            lasersVisible = true;
            Debug.Log("turning on lasers");
        }

        if (other.gameObject.tag == "Button")
        {
            currentCheckpoint = other.transform.position;
            Debug.Log("Button reached");

            //help
            string message = "E";

            //show floating text
            FloatingText.ShowFloatingText(FloatingTextPrefab, other.transform.position, message);

            isOnButton = true;
            
        }

        if (other.gameObject.tag == "flippableObejct")
        {
            currentCheckpoint = other.transform.position;
            Debug.Log("object reached");

            //help
            string message = "E";

            //show floating text
            FloatingText.ShowFloatingText(FloatingTextPrefab, other.transform.position, message);

            isNearObject = true;

        }

        if (other.gameObject.tag == "LockedDoorInfo")
        {
            currentCheckpoint = other.transform.position;
            Debug.Log("Checkpoint reached at: " + currentCheckpoint);

            string message = StringVariables.lockedDoor;

            //show floating text
            FloatingText.ShowFloatingText(FloatingTextPrefab, other.transform.position, message);
        }

        if (other.gameObject.tag == "StartingPointInfo")
        {
            currentCheckpoint = other.transform.position;
            Debug.Log("Checkpoint reached at: " + currentCheckpoint);

            string message = StringVariables.isThisALab;

            //show floating text
            FloatingText.ShowFloatingText(FloatingTextPrefab, other.transform.position, message);
        }

        if (other.gameObject.tag == "FireInfo")
        {
            currentCheckpoint = other.transform.position;
            Debug.Log("Checkpoint reached at: " + currentCheckpoint);

            string message = StringVariables.dontTouchMeFire;

            //show floating text
            FloatingText.ShowFloatingText(FloatingTextPrefab, other.transform.position, message);
        }

        if (other.gameObject.tag == "HammersInfo")
        {
            currentCheckpoint = other.transform.position;
            Debug.Log("Checkpoint reached at: " + currentCheckpoint);

            string message = StringVariables.dontTouchMeObstacles;

            //show floating text
            FloatingText.ShowFloatingText(FloatingTextPrefab, other.transform.position, message);
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

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Button"))
        {
            isOnButton = false;
        }
    }

    /// <summary    
    /// This function handles collision events for the doors.
    /// </summary>
    /// <param name="collision">The collision that is being returned.</param>

    private void OnCollisionEnter(Collision collision)
    {
        /*
        if (collision.gameObject.tag == "Button 1")
        {

            laserScriptReference.lr.enabled = !laserScriptReference.lr.enabled;

            Debug.Log("Button");
        }
        */

        if (collision.gameObject.tag == "Room1ExitDoor")
        {
            if (labKeys >= collision.transform.GetComponent<Door>().Locks)
            {
                //labKeys -= collision.transform.GetComponent<Door>().Locks;
                collision.gameObject.SetActive(false);
                Debug.Log("Unlocked Lab Door");

                //pop up text
                string message = "Unlocked Lab Door";

                //show floating text
                FloatingText.ShowFloatingText(FloatingTextPrefab, collision.gameObject.transform.position, message);

                labKeys = 0;
                Debug.Log("Keys left: " + labKeys);
            }
            else
            {
                if (labKeys < collision.transform.GetComponent<Door>().Locks)
                {
                    int missingLabKeys = collision.transform.GetComponent<Door>().Locks - labKeys;

                    Debug.Log("need " + missingLabKeys + " more lab key(s)");

                    //pop up text
                    string message = "need " + missingLabKeys + " more lab key(s)";

                    //show floating text
                    FloatingText.ShowFloatingText(FloatingTextPrefab, collision.gameObject.transform.position, message);
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

                //pop up text
                string message = StringVariables.unlockedDoor;

                //show floating text
                FloatingText.ShowFloatingText(FloatingTextPrefab, collision.gameObject.transform.position, message);
            }
            else
            {
                if (labKeys < collision.transform.GetComponent<Door>().Locks)
                {
                    int missingLabKeys = collision.transform.GetComponent<Door>().Locks - labKeys;
                    Debug.Log("need " + missingLabKeys + " more lab key(s)");

                    //pop up text
                    string message = "need " + missingLabKeys + " more lab key(s)";

                    //show floating text
                    FloatingText.ShowFloatingText(FloatingTextPrefab, collision.gameObject.transform.position, message);
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

                //pop up text
                string message = "Unlocked Lab Door";

                //show floating text
                FloatingText.ShowFloatingText(FloatingTextPrefab, collision.gameObject.transform.position, message);
            }
            else
            {
                if (labKeys < collision.transform.GetComponent<Door>().Locks)
                {
                    int missingLabKeys = collision.transform.GetComponent<Door>().Locks - labKeys;
                    Debug.Log("need " + missingLabKeys + " more lab key(s)");

                    //pop up text
                    string message = "need " + missingLabKeys + " more lab key(s)";

                    //show floating text
                    FloatingText.ShowFloatingText(FloatingTextPrefab, collision.gameObject.transform.position, message);
                }
            }
        }
        if (collision.gameObject.tag == "LaserHallwayExitDoor")
        {
            if (labKeys >= collision.transform.GetComponent<Door>().Locks)
            {
                //labKeys -= collision.transform.GetComponent<Door>().Locks;
                collision.gameObject.SetActive(false);
                Debug.Log("Unlocked Lab Door");

                //pop up text
                string message = "Unlocked Lab Door";

                //show floating text
                FloatingText.ShowFloatingText(FloatingTextPrefab, collision.gameObject.transform.position, message);

                labKeys = 0;
                Debug.Log("Keys left: " + labKeys);
            }
            else
            {
                if (labKeys < collision.transform.GetComponent<Door>().Locks)
                {
                    int missingLabKeys = collision.transform.GetComponent<Door>().Locks - labKeys;

                    Debug.Log("need " + missingLabKeys + " more lab key(s)");

                    //pop up text
                    string message = "need " + missingLabKeys + " more lab key(s)";

                    //show floating text
                    FloatingText.ShowFloatingText(FloatingTextPrefab, collision.gameObject.transform.position, message);
                }
            }

        }
    }

}
