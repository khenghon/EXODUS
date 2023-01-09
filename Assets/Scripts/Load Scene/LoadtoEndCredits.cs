using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadtoEndCredits : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("End Credits", LoadSceneMode.Single);
    }
}
