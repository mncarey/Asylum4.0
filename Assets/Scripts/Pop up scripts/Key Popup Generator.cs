using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyPopupGenerator : MonoBehaviour
{
    public static KeyPopupGenerator current;
    public GameObject prefab;

    private void Awake()
    {
        current = this;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            CreatePopUp(Vector3.one, Random.Range(0, 1000).ToString());
        }
    }

    public void CreatePopUp(Vector3 position, string text)
    {
        var popup = Instantiate(prefab, position, Quaternion.identity);
        var temp = popup.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        temp.text = text;
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
