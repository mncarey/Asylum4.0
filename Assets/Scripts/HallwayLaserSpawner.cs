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
    public GameObject laserWave1;
    public GameObject laserWave2;
    public GameObject laserWave3;
    public GameObject laserWave4;

    public PlayerController player;
    private float laserSpawnRate;
    public HallwayLaserWave CurrentWave;
    // Start is called before the first frame update
    void Start()
    {
        
        //if (!PauseMenu.isPaused && player.lasersVisible == true)
        //{
        //    Debug.Log("Calling Wave1 from Spawner");
        //    CurrentWave.StartWave1();
        //    Debug.Log("After Wave 1 call");





        //    //SpawnLaserWave1();
        //    //InvokeRepeating("SpawnFire", 1, fireSpawnRate);
        //    //("Spawnlaser" is the name of the function, seconds to wait before starting, how often to call the function)
        //    //InvokeRepeating("SpawnLaser", 5, 5);
        //}

    }

    // Update is called once per frame
    void FixedUpdate()
    {
  
        if (!PauseMenu.isPaused && player.lasersVisible == true)
        {
            Debug.Log("Calling Wave1 from Spawner");
            CurrentWave.StartWave1();
            Debug.Log("After Wave 1 call");

            //SpawnLaserWave1();
            //InvokeRepeating("SpawnFire", 1, fireSpawnRate);
            //("Spawnlaser" is the name of the function, seconds to wait before starting, how often to call the function)
            //InvokeRepeating("SpawnLaser", 5, 5);
        }
    }

    private void SpawnLaserWave1()
    {
        laserWave1.SetActive(true);

    }
}
