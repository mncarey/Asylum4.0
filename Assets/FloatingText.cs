using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class FloatingText : MonoBehaviour
{
    public float DestroyTime = 3f;
    public string displayText = "base text";
    public Vector3 offset = new Vector3(0, 2f, 0);
    private Transform player;
    
   


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        TextMesh textMesh = GetComponent<TextMesh>();

        if(textMesh != null)
        {
            textMesh.text = displayText;
        }

        Destroy(gameObject, DestroyTime);
    }

    void Update()
    {
        if (player != null)
        {
            transform.LookAt(player);
            transform.rotation = Quaternion.LookRotation(transform.position - player.position);
        }
    }

    public static void ShowFloatingText(GameObject prefab, Transform player, Vector3 position)
    {
        // Instantiate above the collision point
        GameObject go = Instantiate(prefab, position + Vector3.up * 2f, Quaternion.identity, player);
    }
}
