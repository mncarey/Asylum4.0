using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlippableObject : MonoBehaviour
{
    public LayerMask groundLayer;
    public bool isGravityFlipped = false;
    public PlayerController playerReference;
    private Rigidbody rb;
    private Vector3 originalGravity;
    private float gravityStrength = 9.81f;
    private bool ready = false;

    public FlippableObject parentObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController pc = other.GetComponent<PlayerController>();//getting a reference to playerController
            if(pc != null)
            {
                pc.currentTarget = parentObject;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController pc = other.GetComponent<PlayerController>();
            if(pc != null && pc.currentTarget == parentObject)
            {
                pc.currentTarget = null;
            }
        }
    }
    //raycasts
    public Vector3[] rayCasts = new Vector3[]
    {
        new Vector3(0.5f, 0, 0.5f),
        new Vector3(0.5f, 0, -0.5f),
        new Vector3(-0.5f, 0, 0.5f),
        new Vector3(-0.5f, 0, -0.5f),

        Vector3.zero //<- center rays
    };

    public float rayLength = 0.5f;

    public bool IsGrounded()
    {
        foreach (Vector3 offset in rayCasts)
        {
            Vector3 origin = transform.position + offset;

            if (Physics.Raycast(origin, Vector3.down, rayLength, groundLayer))//if the raycast hits
            {
                return true;
            }
            
        }
        Debug.Log("Noot gorunded.");
        return false;
    }

    public bool IsOnCeiling()
    {
        foreach (Vector3 offset in rayCasts)
        {
            Vector3 origin = transform.position + offset;

            if (Physics.Raycast(origin, Vector3.up, rayLength, groundLayer))//if the raycast hits
            {
                return true;
            }

        }
        Debug.Log("Noot on ceiling.");
        return false;
    }


    IEnumerator Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

        originalGravity = Physics.gravity;

        yield return new WaitForFixedUpdate(); // allow physics to settle
        ready = true;
    }
   

    // Update is called once per frame
    void Update()
    {
        if(playerReference.flipObject() == true)
        {
            TryGravityFlip();
        }
    }

    void FixedUpdate()
    {
        if (!ready) return;

        //custom gravity
        Vector3 gravityDir = isGravityFlipped ? Vector3.up : Vector3.down;
        rb.AddForce(gravityDir * 9.81f, ForceMode.Acceleration);

        //Stop sliding on X/Z
        Vector3 v = rb.velocity;
        v.x = 0;
        v.z = 0;
        rb.velocity = v;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        if (rayCasts == null) return;

        foreach (Vector3 offset in rayCasts)
        {
            Vector3 origin = transform.position + offset;
            Vector3 end = origin + Vector3.down * rayLength;

            Gizmos.DrawLine(origin, end);
            Gizmos.DrawSphere(end, 0.07f); //tiny sphere at the hit point
        }
    }

    private void TryGravityFlip()
    {
        //checking object position
       // bool isOnGround = Physics.CheckSphere(transform.position + Vector3.down * 0.3f, 0.5f, groundLayer);
       // bool isOnCeiling = Physics.CheckSphere(transform.position + Vector3.up * 0.3f, 0.5f, groundLayer);
       
            if (IsGrounded() == true || IsOnCeiling() == true)
            {
            Debug.Log("Object is grounded");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Trying to anti gravity.");
                    // detach impulse
                    rb.velocity = Vector3.zero;

                    float impulse = 2f; // tweak this as needed
                    if (isGravityFlipped)
                        rb.AddForce(Vector3.down * impulse, ForceMode.Impulse);
                    else
                        rb.AddForce(Vector3.up * impulse, ForceMode.Impulse);

                    // finally flip gravity
                    isGravityFlipped = !isGravityFlipped;
                }
           
            }
            else Debug.Log("Not touching ground or ceiling.");
        
    }
    
}
