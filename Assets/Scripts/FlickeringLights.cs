using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author: [Barajas, Daniela] 
 * Date Created: [12/08/2025]
 * Last Updated: [12/08/2025]
 * [This will handle flickering of lights]
 */
[RequireComponent(typeof(Light))]

public class FlickeringLights : MonoBehaviour
{
    private Light lightToFlicker;
    [SerializeField, Range(0f, 3f)] private float minIntensity = 0.5f;
    [SerializeField, Range(0f, 3f)] private float maxIntensity = 2.5f;
    [SerializeField, Min(0f)] private float timeBtwnIntensity = 0.1f;

    private float currentTimer;
    private void Awake()
    {
        if(lightToFlicker == null)
        {
            lightToFlicker = GetComponent<Light>();
        }
        ValidateIntensityBounds();
    }

    private void FixedUpdate()
    {
        currentTimer += Time.deltaTime;
        if (!(currentTimer >= timeBtwnIntensity)) return;
        lightToFlicker.intensity = Random.Range(minIntensity, maxIntensity);
        currentTimer = 0;
    }

    private void ValidateIntensityBounds()
    {
        if (!(minIntensity > maxIntensity))
        {
            return;
        }
        (minIntensity, maxIntensity) = (maxIntensity, minIntensity);
    }
}
