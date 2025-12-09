using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Barajas, Daniela]
 * Date Created: [12/09/2025]
 * Last Updated: [12/09/2025]
 * [This will handle movement for ceiling fans.]
 */

public class CeilingFans : MonoBehaviour
{

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!PauseMenu.isPaused)
        {
            transform.Rotate(0, 5f, 0);
        }
    }
}
