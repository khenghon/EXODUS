using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadtoEndEncounter : MonoBehaviour
{
    public Transform enemy1;
    public Transform enemy2;
    public Transform enemy3;
    public Transform enemy4;
    public Transform enemy5;
    void Update()
    {
        if (enemy1 == null && enemy2 == null && enemy3 == null && enemy4 == null && enemy5 == null)
            LoadNext();
    }
    void LoadNext()
    {
        SceneManager.LoadScene("End Encounter", LoadSceneMode.Single);
    }

}
