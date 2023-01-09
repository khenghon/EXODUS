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
    public Transform enemy6;
    public Transform enemy7;
    public Transform enemy8;
    public Transform enemy9;
    public Transform enemy10;
    public Transform enemy11;
    public Transform enemy12;
    void Update()
    {
        if (enemy1 == null && enemy2 == null && enemy3 == null && enemy4 == null && enemy5 == null && enemy6 == null && 
            enemy7 == null && enemy8 == null && enemy9 == null && enemy10 == null && enemy11 == null && enemy12 == null)
            LoadNext();
    }
    void LoadNext()
    {
        SceneManager.LoadScene("End Encounter", LoadSceneMode.Single);
    }

}
