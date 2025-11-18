using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLaserSpawner : MonoBehaviour
{
    public bool killTheLasers;
    public PlayerController player;
    public GameObject laser1;
    public GameObject laser2;
    public GameObject laser3;
    public GameObject laser4;
    public LaserScript laserScriptReference;

    // Start is called before the first frame update
    void Start()
    {

        ////killTheLasers = false;
        //laser1.SetActive(false);
        //laser2.SetActive(false);
        //laser3.SetActive(false);
        //laser4.SetActive(false);

        //laserScriptReference.lr.enabled = !laserScriptReference.lr.enabled;
    }

    public void ActivateLasers()
    {
        laser1.SetActive(true);
        laser2.SetActive(true);
        laser3.SetActive(true);
        laser4.SetActive(true);
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
    
    
}
