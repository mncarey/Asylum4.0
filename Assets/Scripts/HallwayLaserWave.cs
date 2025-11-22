using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Barajas, Daniela] [Martinez, Nick]
 * Date Created: [11/13/2025]
 * Last Updated: [11/21/2025]
 * [This will handle movement and collision for the Laser Waves.]
 */
public class HallwayLaserWave : MonoBehaviour
{
    private float movementSpeed = 5f;
    //public Vector3 startpoint; 
    private int waveNumber;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDestruct());

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

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(15f);
        Destroy(gameObject);
    }
  

}
