using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 * Author: [Martinez, Nick]
 * Date Created: [11/26/2025]
 * Last Updated: [11/26/2025]
 * [This will handle movement for the turret bullet.]
 */
public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
