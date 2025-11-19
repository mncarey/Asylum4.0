using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlippableObject : MonoBehaviour
{
    public LayerMask groundLayer;
    public bool isGravityFlipped = false;
    public Vector3 originalGravity;
    public PlayerController playerReference;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerReference.flipObject() == true)
        {
            GravityFlip();
        }
    }

    
    private void GravityFlip()
    {
        //checking object position
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
    
}
