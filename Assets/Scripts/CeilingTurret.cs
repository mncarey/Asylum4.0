using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Martinez, Nick]
 * Date Created: [11/26/2025]
 * Last Updated: [11/26/2025]
 * [This will handle the ceiling turret behavior
 * ]
 */

public class CeilingTurret : MonoBehaviour
{
    public Transform head;
    // this will call the part of the turret that rotates

    public Transform firePoint;
    // this will call the part of the turret that the bullets will spawn from

    public GameObject bulletPrefab;
    // this will call the bullet to be spawned

    public float rotationSpeed = 5f;
    // this will be how fast the turret rotates towards the player

    public float fireRate = 1f;
    // this will track how many bullets the turret shoots per second

    public Vector3 rotationOffsetEuler = Vector3.zero;
    // this will fix the rotation of the turret 

    private float nextFireTime = 0f;
    // this stores the next moment when the turret can shoot again

    private Transform player;
    // this will store the players transform once the player enters the detection zone, until then its null

    private bool playerInRange = false;
    // this will check whether or not the player is inside the detection zone

    // Start is called before the first frame update
    void Start()
    {
    // Update is called once per frame
        
    }

    void Update()
    {
        if (!playerInRange || player == null)
            return;
        RotateTowardPlayer();
        HandleShooting();

    }

    //this function handles the rotation of the turret head towards the player
    private void RotateTowardPlayer()
    { 
        Vector3 direction = player.position - head.position;

        if (direction == Vector3.zero)
            return;

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        targetRotation *= Quaternion.Euler(rotationOffsetEuler);

        head.rotation = Quaternion.Slerp(head.rotation,targetRotation, rotationSpeed * Time.deltaTime);
    }

    //this function handles the fire rate of the bullets
    private void HandleShooting()
    {
        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;
            Shoot();
            Debug.Log("SHOOT() WAS CALLED!");

        }
    }

    private void Shoot()
    {
        //checks if Fire Point or Bullet are missing, if they aren't then spawn a bullet prefab

        if (bulletPrefab == null || firePoint == null)
            return;

        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
       
    }

    //this function handles the collision enter of the detection zone, setting the players transform and target to true
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;

            playerInRange = true;
           
        }
    }

    //this handles the on trigger exit of the detection zone
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && other.transform == player)
        {
            playerInRange = false;

            player = null;
        }
    }
}
