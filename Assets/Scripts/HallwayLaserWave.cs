using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Barajas, Daniela] [Martinez, Nick]
 * Date Created: [11/13/2025]
 * Last Updated: [11/13/2025]
 * [This will handle movement and collision for the player.]
 */
public class HallwayLaserWave : MonoBehaviour
{
    public bool killTheLasers;
    public PlayerController player;
    public GameObject laserWave1;
    public GameObject laserWave2;
    public GameObject laserWave3;
    public GameObject laserWave4;
    public float movementSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        //killTheLasers = false;
        laserWave1.SetActive(false);
        laserWave2.SetActive(false);
        laserWave3.SetActive(false);
        laserWave4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //if (player.lasersVisible == true)
        //{
        //    //Debug.Log("in HallwayLaserWave laserVisib=le should be true");
        //    killTheLasers = true;
        //    //MoveLasers();
 
        //}
        //else if (player.lasersVisible == false && killTheLasers == true)
        //{
        //    //Debug.Log("DOES THIS WQORK");
        //   // Destroy(gameObject);
        //}
    }
    public void StartWave1()
    {
        Debug.Log("In Start Wave 1 in HallwayLaserWaveScript");
        laserWave1.SetActive(true);
        MoveLasers();
    }
    private void MoveLasers()
    {

        transform.position += Vector3.forward * movementSpeed * Time.deltaTime;
    }
}
