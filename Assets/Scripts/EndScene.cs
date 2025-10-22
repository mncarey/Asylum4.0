using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author: [Barajas, Daniela]
 * Date Created: [10/20/2025]
 * Last Updated: [10/20/2025]
 * [This will handle Main Menu and Game Over scene.]
 */
public class EndScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    /// <summary>
    /// This function quits the game.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
    /// <summary>
    /// This function handles scene management.
    /// </summary>

    public void SwitchScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
