using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;
    private GameObject playerView;

    void Start()
    {
        playerView = GameObject.Find("Weapon Socket");
        pauseMenu.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
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
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PauseGame()
    {
        playerView.SetActive(false);
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        isPaused = true;

    }
    public void ResumeGame()
    {
        playerView.SetActive(true);
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