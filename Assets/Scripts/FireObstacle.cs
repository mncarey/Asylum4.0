using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Author: [Barajas, Daniela]
 * Date Created: [10/20/2025]
 * Last Updated: [10/20/2025]
 * [This will handle movement for fire obstacle in Room 2.]
 */

public class FireObstacle : MonoBehaviour
{

    public GameObject firePrefab;
    public float fireSpawnRate = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnFire", 1, fireSpawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnFire()
    {
        Instantiate(firePrefab, transform.position, transform.rotation);
    }
}
