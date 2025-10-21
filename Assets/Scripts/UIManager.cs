using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;

/*
 * Author: [Barajas, Daniela]
 * Date Created: [10/20/2025]
 * Last Updated: [10/20/2025]
 * [This will handle UI for the game.]
 */
public class UIManager : MonoBehaviour
{
    public PlayerController playerController;
    TMP_Text livesText;
    TMP_Text objectiveText;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + playerController.lives;
    }
}
