using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
            RestartGame();
        {
            //if (GameIsPaused)
            //{
                
            //    Resume();
            //}else
            //{
            //    Pause();
            //}
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    //void Resume()
    //{
    //    pauseMenuUI.SetActive(false);
    //    Time.timeScale = 1f;
    //    GameIsPaused = false;
    //}
    //void Pause()
    //{
    //    pauseMenuUI.SetActive(true);
    //    Time.timeScale = 0f;
    //    GameIsPaused = true;
    //}

}
