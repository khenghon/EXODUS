using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause_Menu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;

    public void QuitGame()
    {
        Application.Quit();
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        isPaused = true;

    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


}