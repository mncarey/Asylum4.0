using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLaserSpawner : MonoBehaviour
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


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!PauseMenu.isPaused && player.lasersVisible == true)
        {
            Debug.Log("Calling Wave1 from Spawner");
            CurrentWave.StartWave1();
            Debug.Log("After Wave 1 call");
        }
    }

    private void SpawnLaserWave1()
    {
        laserWave1.SetActive(true);

    }
}
