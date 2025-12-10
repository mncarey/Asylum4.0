using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;
using Unity.VisualScripting;

/*
 * Author: [Barajas, Daniela]
 * Date Created: [10/20/2025]
 * Last Updated: [10/20/2025]
 * [This will handle UI for the game.]
 */
public class UIManager : MonoBehaviour
{
    public PlayerController playerController;
   // public TMP_Text livesText;
    //public TMP_Text objectiveText;
    public TMP_Text gravityMechanic;
    Vector3 positiveVectors = new Vector3(0f, -9.81f, 0f);

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        //livesText.text = "Lives: " + playerController.lives;

        if (playerController.isGravityFlipped == false)
        {
            gravityMechanic.text = "Anti-Gravity: off";
        } else
            gravityMechanic.text = "Anti-Gravity: on";

    }
}
