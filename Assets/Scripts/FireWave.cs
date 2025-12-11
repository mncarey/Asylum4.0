using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Author: [Barajas, Daniela]
 * Date Created: [10/20/2025]
 * Last Updated: [10/21/2025]
 * [This will handle movement for fire wave in Room 2.]
 */

public class FireWave : MonoBehaviour
{

    //movement speed in units per second
    public float movementSpeed = 12f;
    //private Rigidbody2D _rb;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    //this is for destroying the game object after 5 seconds so it doesnt move forever

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
    private void Awake()
    {
        //_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position += Vector3.back * movementSpeed * Time.deltaTime;
        //_rb.velocity = _rb.GetRelativeVector(Vector3.back).normalized * movementSpeed * Time.fixedDeltaTime;

    }
}
