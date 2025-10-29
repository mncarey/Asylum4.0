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
    private float fireSpawnRate;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnFire", 1, fireSpawnRate);
        //("SpawnFire" is the name of the function, seconds to wait before starting, how often to call the function)
        InvokeRepeating("SpawnFire", Random.Range(1, 4), Random.Range(2, 8));
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
