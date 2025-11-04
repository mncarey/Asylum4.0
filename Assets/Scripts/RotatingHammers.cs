using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Barajas, Daniela]
 * Date Created: [10/20/2025]
 * Last Updated: [10/20/2025]
 * [This will handle movement for hammer obstacle in Room 2.]
 */

public class RotatingHammers : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            transform.Rotate(0, .5f, 0);
        }
    }
}
