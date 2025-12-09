using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Barajas, Daniela] [Carey, Madison]
 * Date Created: [11/12/2025]
 * Last Updated: [12/06/2025]
 * [This will handle movement for laser obstacle in the hallway between rooms 3 and 4]
 */

public class HallwayLaserSpawner : MonoBehaviour
{
    public GameObject laserWave1Prefab;
    public GameObject laserWave2Prefab;
    public GameObject laserWave3Prefab;
    public GameObject laserWave4Prefab;
    public GameObject laserWave5Prefab;
    public float laserWaveSpawnRate;
    private bool laserBool;

    public PlayerController player;
    private float laserSpawnRate = 5;
    //public HallwayLaserWave Waves;
    private int waveNumber = 0;

    private bool wavesStarted;

    // Update is called once per frame
    void FixedUpdate()
    {
        //CheckIfPlayerHasPassedEntry();
        laserBool = CheckIfPlayerHasPassedEntry();
        Debug.Log("Bool is: " + laserBool);
        //StartTheWaves() can be called exactly once
        if(!laserBool)
        {
            StopTheWaves();
            return;
        }
        if (laserBool && wavesStarted == false)
        {
            StartTheWaves();
            return;
        }
    }

    //Start is called before the first frame update
    void Start()
    {
        
    }

    private void StartTheWaves()
    {
        Debug.Log("Starting waves");
        //waveNumber = GenerateNumber();
        wavesStarted = true; //prevents the waves from spawning every update
        //("SpawnWave" is the name of the function, seconds to wait before starting, how often to call the function)
        InvokeRepeating(nameof(SpawnWave), 0, laserSpawnRate);
    }

    private bool CheckIfPlayerHasPassedEntry()
    {
        if (player.lasersVisible == true)
        {
            return true;
        }
        Debug.Log("After True IF");
        return false;
    }

    private void StopTheWaves()
    {
        CancelInvoke();
    }


    private void SpawnWave()
    {
        Debug.Log("In SpawnWave()");
        //waveNumber = GenerateNumber();
        waveNumber++;
        Debug.Log("Wave: " + waveNumber);       
        //waveNumber = 1;
        if (waveNumber > 5)
        {
            waveNumber = 1;
        }

        if (waveNumber == 1)
        {
            Debug.Log("Starting wave 1");
            Instantiate(laserWave1Prefab, transform.position, transform.rotation);
            waveNumber++;
        }
        else if (waveNumber == 2)
        {
            Debug.Log("Starting wave 2");
            Instantiate(laserWave2Prefab, transform.position, transform.rotation);
            waveNumber++;
        }
        else if (waveNumber == 3)
        {
            Debug.Log("Starting wave 3");
            Instantiate(laserWave3Prefab, transform.position, transform.rotation);
            waveNumber++;
        }
        else if (waveNumber == 4)
        {
            Instantiate(laserWave4Prefab, transform.position, transform.rotation);
            waveNumber++;
        }
        else if (waveNumber == 5)
        {
            Instantiate(laserWave5Prefab, transform.position, transform.rotation);
            waveNumber = 1;
        }


    }
    private int GenerateNumber()
    {
        return Random.Range(1, 6); // returns 1–5
    }

}
