using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLaserSpawner : MonoBehaviour
{
    public bool killTheLasers;
    public PlayerController player;
    public LaserScript laser1;
    public LaserScript laser2;
    public LaserScript laser3;
    public LaserScript laser4;
    public LaserScript laser5;
    public LaserScript laser6;
    public LaserScript laser7;
    public LaserScript laser8;
    public LaserScript laser9;
    public LaserScript laser10;
    public LaserScript laser11;
    public LaserScript laser12;
    public LaserScript laser13;
    public LaserScript laser14;
    public LaserScript laser15;
    public LaserScript laser16;
    public LaserScript laser17;
    public LaserScript laser18;
    public LaserScript laser19;
    public LaserScript laser20;
    public LaserScript laserScriptReference;

    // Start is called before the first frame update
    void Start()
    {
        killTheLasers = false;
        laser1.lr.enabled = false;
        laser2.lr.enabled = false;
        laser3.lr.enabled = false;
        laser4.lr.enabled = false;
        laser5.lr.enabled = false;
        laser6.lr.enabled = false;
        laser7.lr.enabled = false;
        laser8.lr.enabled = false;
        laser9.lr.enabled = false;
        laser10.lr.enabled = false;
        laser11.lr.enabled = false;
        laser12.lr.enabled = false;
        laser13.lr.enabled = false;
        //laser14.lr.enabled = false;
        //laser15.lr.enabled = false;
        //laser16.lr.enabled = false;
        //laser17.lr.enabled = false;
        //laser18.lr.enabled = false;
        //laser19.lr.enabled = false;
        //laser20.lr.enabled = false;
    }

    public void ActivateLasers()
    {
        laser1.lr.enabled = true;
        laser2.lr.enabled = true;
        laser3.lr.enabled = true;
        laser4.lr.enabled = true;
        laser5.lr.enabled = true;
        laser6.lr.enabled = true;
        laser7.lr.enabled = true;
        laser8.lr.enabled = true;
        laser9.lr.enabled = true;
        laser10.lr.enabled = true;
        laser11.lr.enabled = true;
        laser12.lr.enabled = true;
        laser13.lr.enabled = true;
        //laser14.lr.enabled = true;
        //laser15.lr.enabled = true;
        //laser16.lr.enabled = true;
        //laser17.lr.enabled = true;
        //laser18.lr.enabled = true;
        //laser19.lr.enabled = true;
        //laser20.lr.enabled = true;

    }
    // Update is called once per frame
    void Update()
    {
        if (killTheLasers == true)
        {
            laser1.lr.enabled = false;
            laser2.lr.enabled = false;
            laser3.lr.enabled = false;
            laser4.lr.enabled = false;
            laser5.lr.enabled = false;
            laser6.lr.enabled = false;
            laser7.lr.enabled = false;
            laser8.lr.enabled = false;
            laser9.lr.enabled = false;
            laser10.lr.enabled = false;
            laser11.lr.enabled = false;
            laser12.lr.enabled = false;
            laser13.lr.enabled = false;
            //laser14.lr.enabled = false;
            //laser15.lr.enabled = false;
            //laser16.lr.enabled = false;
            //laser17.lr.enabled = false;
            //laser18.lr.enabled = false;
            //laser19.lr.enabled = false;
            //laser20.lr.enabled = false;
        }
        else
        {
            ActivateLasers();
        }
    }
    
    
}
