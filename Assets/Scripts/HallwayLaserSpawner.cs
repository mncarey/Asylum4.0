using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Barajas, Daniela]
 * Date Created: [11/12/2025]
 * Last Updated: [11/16/2025]
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

    public PlayerController player;
    private float laserSpawnRate = 10;
    //public HallwayLaserWave Waves;
    private int waveNumber = 0;

    private bool wavesStarted = false;

    void Update()
    {
        //StartTheWaves() can be called exactly once
        if (player.lasersVisible && wavesStarted == false)
        {
            StartTheWaves();
        }
    }

    //Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   
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
        else
        {
            return false;
        }
    }


    private void SpawnWave()
    {
        //waveNumber = GenerateNumber();
        waveNumber++;
        if (waveNumber > 5)
        {
            waveNumber = 1;
        }

        if (waveNumber == 1)
        {
            Instantiate(laserWave1Prefab, transform.position, transform.rotation);
            waveNumber++;
        }
        else if (waveNumber == 2)
        {
            Instantiate(laserWave2Prefab, transform.position, transform.rotation);
            waveNumber++;
        }
        else if (waveNumber == 3)
        {
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
