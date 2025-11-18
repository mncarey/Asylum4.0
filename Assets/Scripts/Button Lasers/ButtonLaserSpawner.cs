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
    public LaserScript laserScriptReference;

    // Start is called before the first frame update
    void Start()
    {
        killTheLasers = false;
        laser1.lr.enabled = false;
        laser2.lr.enabled = false;
        laser3.lr.enabled = false;
        laser4.lr.enabled = false;

    }

    public void ActivateLasers()
    {
        laser1.lr.enabled = true;
        laser2.lr.enabled = true;
        laser3.lr.enabled = true;
        laser4.lr.enabled = true;
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
        }
        else
        {
            ActivateLasers();
        }
    }
    
    
}
