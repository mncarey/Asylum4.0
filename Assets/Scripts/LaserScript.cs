using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Carey, Madison] [Barajas, Daniela] 
 * Date Created: [11/13/2025]
 * Last Updated: [11/21/2025]
 * [This will handle movement and collision for the Lasers.]
 */

public class LaserScript : MonoBehaviour
{
    public LineRenderer lr;
    [SerializeField]
    private Transform startPoint;
    public GameObject Player;
    public float movementSpeed = 25;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.enabled = true;
        GenerateMeshCollider();
    }

    void Update()
    {
        lr.SetPosition(0, startPoint.position);
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.right, out hit))
        {
            if (hit.collider)
            {
                lr.SetPosition(1, hit.point);
            }
            if (hit.transform.tag == "Player")
            {
                // Destroy(hit.transform.gameObject);
                Player.GetComponent<PlayerController>().Respawn();
            }
        }
        else lr.SetPosition(1, -transform.right * 5000);

    }

    public void GenerateMeshCollider()
    {
        MeshCollider collider = GetComponent<MeshCollider>();
        if (collider == null)
        {
            collider = gameObject.AddComponent<MeshCollider>();
        }
        Debug.Log("Generated Mesh Collider");
        Mesh mesh = new Mesh();
        lr.BakeMesh(mesh, true);
        collider.sharedMesh = mesh;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit Player");
            // Destroy(hit.transform.gameObject);
            Player.GetComponent<PlayerController>().Respawn();
            Debug.Log("Respawning Player");
        }
    }

}
