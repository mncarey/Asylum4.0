using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyPopupAnimation : MonoBehaviour
{
    public AnimationCurve opacityCurve;

    private TextMeshProUGUI tmp;
    private float time = 0;

    private void Awake()
    {
        tmp = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        tmp.color = new Color(1, 1, 1, opacityCurve.Evaluate(time));
        time += Time.deltaTime;
        
    }
}
