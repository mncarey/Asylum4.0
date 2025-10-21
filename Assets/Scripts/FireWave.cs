using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Author: [Barajas, Daniela]
 * Date Created: [10/20/2025]
 * Last Updated: [10/20/2025]
 * [This will handle movement for fire wave in Room 2.]
 */

public class FireWave : MonoBehaviour
{

    //movement speed in units per second
    private float movementSpeed = 5f;
    private Rigidbody2D _rb;


    // Start is called before the first frame update
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        _rb.velocity = _rb.GetRelativeVector(Vector3.back).normalized * movementSpeed * Time.fixedDeltaTime;

    }
}
