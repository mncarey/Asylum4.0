using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author: [Barajas, Daniela] 
 * Date Created: [11/02/2025]
 * Last Updated: [11/4/2025]
 * [This will manage the pause menu.]
 */
public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)){
            Debug.Log("Esc pressed:V");
            Cursor.lockState = CursorLockMode.None;
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    
    /// <summary>
    /// This function resumes game.
    /// </summary>
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
    }
    
    /// <summary>
    /// This function handles pauses game.
    /// </summary>
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    
    /// <summary>
    /// This function handles scene management.
    /// </summary>
    public void SwitchScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1f;
    }
    
    /// <summary>
    /// This function quits the game.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
