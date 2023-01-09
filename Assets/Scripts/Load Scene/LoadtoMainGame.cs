using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadtoMainGame : MonoBehaviour
{
    public void OnEnable()
    {
        SceneManager.LoadScene("Terrain and sky", LoadSceneMode.Single);
    }
}
