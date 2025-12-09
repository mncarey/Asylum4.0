using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Author: [Barajas, Daniela]
 * Date Created: [10/20/2025]
 * Last Updated: [12/08/2025]
 * [This will handle movement for fire obstacle in Room 2.]
 */

public class FireObstacle : MonoBehaviour
{

    public GameObject firePrefab;
    private float fireSpawnRate;
    private bool fireBool;
    private bool wavesStarted;

    public PlayerController player;
    // Start is called before the first frame update
    void Start()
        
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!PauseMenu.isPaused)
        {
            //CheckIfPlayerHasPassedEntry();
            fireBool = CheckIfPlayerHasPassedEntry();
            //Debug.Log("Bool is: " + laserBool);
            //StartTheWaves() can be called exactly once
            if (!fireBool)
            {
                StopTheWaves();
                return;
            }
            if (fireBool && wavesStarted == false)
            {
                StartTheWaves();
                return;
            }
        }

    }

    private void StartTheWaves()
    {
        Debug.Log("Starting waves");
        wavesStarted = true; //prevents the waves from spawning every update
        InvokeRepeating("SpawnFire", Random.Range(1, 4), Random.Range(2, 8));
    }
    private void SpawnFire()
    {
        Instantiate(firePrefab, transform.position, transform.rotation);
    }

    private void StopTheWaves()
    {
        CancelInvoke();
    }

    private bool CheckIfPlayerHasPassedEntry()
    {
        if (player.fireVisible == true)
        {
            return true;
        }
        
        return false;
    }
}
