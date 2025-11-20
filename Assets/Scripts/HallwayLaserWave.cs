using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Barajas, Daniela] [Martinez, Nick]
 * Date Created: [11/13/2025]
 * Last Updated: [11/13/2025]
 * [This will handle movement and collision for the Laser Waves.]
 */
public class HallwayLaserWave : MonoBehaviour
{

    //public bool killTheLasers;
    //public PlayerController player;
    //public GameObject laserWave1;
    //public GameObject laserWave2;
    //public GameObject laserWave3;
    //public GameObject laserWave4;
    private float movementSpeed = 5f;
    //public Vector3 startpoint; 
    private int waveNumber;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDestruct());
        //transform.position += Vector3.forward * movementSpeed * Time.deltaTime;
        //Debug.Log("Moving Lasers");
        // MoveLasers();
        //laserWave1.SetActive(false);
        //laserWave2.SetActive(false);
        //laserWave3.SetActive(false);
        //laserWave4.SetActive(false);
        //if (!PauseMenu.isPaused && player.lasersVisible == true)
        //{
        //    waveNumber = GenerateNumber();
        //    //("SpawnFire" is the name of the function, seconds to wait before starting, how often to call the function)
        //    switch (waveNumber)
        //    {
        //        case 4:
        //            Debug.Log("In Case 4");
        //            InvokeRepeating("SpawnWave4", 0, 1);
        //            break;
        //        case 3:
        //            Debug.Log("In Case 3");
        //            InvokeRepeating("SpawnWave3", 0, 1);
        //            break;
        //        case 2:
        //            Debug.Log("In Case 2");
        //            InvokeRepeating("SpawnWave2", 0, 1);
        //            break;
        //        case 1:
        //            Debug.Log("In Case 1");
        //            InvokeRepeating("SpawnWave1", 0, 1);
        //            break;
        //        default:
        //            Debug.Log("In Defaultc case");
        //            InvokeRepeating("SpawnWave1", 0, 1);
        //            break;
        //    }
        //}
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (!PauseMenu.isPaused && player.lasersVisible == true)
        //{
        //    RunWaves();
        //}
        transform.position += Vector3.forward * movementSpeed * Time.deltaTime;
        Debug.Log("Moving Lasers");
    }
    // private void OnCollisionEnter()
    //{
    //    if (hit.transform.tag == "Player")
    //    {
    //        // Destroy(hit.transform.gameObject);
    //        Player.GetComponent<PlayerController>().Respawn();
    //    }
    //}
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(15f);
        Destroy(gameObject);
    }
    //private void RunWaves()
    //{
    //    waveNumber = 1;
    //    //waveNumber = GenerateNumber();
    //    //("SpawnWave#" is the name of the function, seconds to wait before starting, how often to call the function)
    //    switch (waveNumber)
    //    {
    //        case 4:
    //            Debug.Log("In Case 4");
    //            InvokeRepeating("SpawnWave4", 0, 1);
    //            StartCoroutine(WaintInBetweenWaves());
    //            break;
    //        case 3:
    //            Debug.Log("In Case 3");
    //            InvokeRepeating("SpawnWave3", 0, 1);
    //            StartCoroutine(WaintInBetweenWaves());
    //            break;
    //        case 2:
    //            Debug.Log("In Case 2");
    //            InvokeRepeating("SpawnWave2", 0, 1);
    //            StartCoroutine(WaintInBetweenWaves());
    //            break;
    //        case 1:
    //            Debug.Log("In Case 1");
    //            InvokeRepeating("SpawnWave1", 0, 1);
    //            StartCoroutine(WaintInBetweenWaves());
    //            break;
    //        default:
    //            Debug.Log("In Defaultc case");
    //            InvokeRepeating("SpawnWave1", 0, 1);
    //            StartCoroutine(WaintInBetweenWaves());
    //            break;
    //    }
    //}
    //IEnumerator WaintInBetweenWaves()
    //{
    //    //yield on a new YieldInstruction that waits for 5 seconds.
    //    yield return new WaitForSeconds(5);
    //}

    //private void SpawnWave4()
    //{
    //    Debug.Log("In SpawnWave4");
    //    Instantiate(laserWave4, transform.position, transform.rotation);
    //    Debug.Log("In SpawnWave4 after instantiation");
    //}
    //private void SpawnWave3()
    //{
    //    Debug.Log("In SpawnWave3");
    //    Instantiate(laserWave3, transform.position, transform.rotation);
    //    Debug.Log("In SpawnWave3 after instantiation");
    //}
    //private void SpawnWave2()
    //{
    //    Debug.Log("In SpawnWave2");
    //    Instantiate(laserWave2, transform.position, transform.rotation);
    //    Debug.Log("In SpawnWave2 after instantiation");
    //}
    //private void SpawnWave1()
    //{
    //    Debug.Log("In SpawnWave1");
    //    Instantiate(laserWave1, transform.position, transform.rotation);
    //    Debug.Log("In SpawnWave1 after instantiation");
    //}
    //private void MoveLasers()
    //{

    //    transform.position += Vector3.forward * movementSpeed * Time.deltaTime;
    //    Debug.Log("Moving Lasers");
    //    //return;

    //}



}
