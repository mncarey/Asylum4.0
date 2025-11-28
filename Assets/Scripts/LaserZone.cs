using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserZone : MonoBehaviour
{
    public ButtonLaserSpawner laserSpawnerToAssign; 

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            player.SetCurrentLaserSpawner(laserSpawnerToAssign);
        }
    }
}