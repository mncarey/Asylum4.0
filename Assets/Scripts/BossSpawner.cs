using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject bossToActivate;
    public GameObject canvasToActivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvasToActivate.SetActive(true);

            bossToActivate.SetActive(true);
            Debug.Log("Boss activated!");

           

        }
    }
}
