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

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + Vector3.down * 0.2f, 0.5f);
    }
    private void TryGravityFlip()
    {
        //checking object position
        bool isOnGround = Physics.CheckSphere(transform.position + Vector3.down * 0.3f, 0.5f, groundLayer);
        bool isOnCeiling = Physics.CheckSphere(transform.position + Vector3.up * 0.3f, 0.5f, groundLayer);
       
            if (isOnGround || isOnCeiling)
            {
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
