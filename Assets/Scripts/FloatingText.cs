using System.Collections;
using System.Collections.Generic;
using UnityEditor;
//using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UIElements;

public class FloatingText : MonoBehaviour
{
    public float DestroyTime = 3f;
   // public string displayText = "base text";
    public Vector3 offset = new Vector3(0, 2f, 0);
    private Transform player;
    private Rigidbody rb;
    private TextMesh textMesh;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        textMesh = GetComponent<TextMesh>();

        Destroy(gameObject, DestroyTime);
    }

    void Update()
    {
        if (Camera.main != null)
        {
            //only rotate on y axis
            Vector3 direction = Camera.main.transform.position - transform.position;
            direction.y = 0;

            //if (direction.sqrMagnitude > 0.001f)
            //{
                transform.rotation = Quaternion.LookRotation(direction);
            //}
        }
        
    }

    private void FixedUpdate()
    {
        //Stop sliding on X/Z
        
    }
    public void SetText(string message)
    {
        if (textMesh == null)
            textMesh = GetComponent<TextMesh>();

        textMesh.text = message;
    }

    public static void ShowFloatingText(GameObject prefab, Vector3 position, string message)
    {
        GameObject go = Instantiate(prefab, position + Vector3.up * 1f, Quaternion.identity);
        FloatingText ft = go.GetComponent<FloatingText>();
        if (ft != null)
        {
            ft.SetText(message);
        }
    }
}
