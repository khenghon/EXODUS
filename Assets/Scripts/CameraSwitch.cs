using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject playerCamera;
    public GameObject inspectCamera;
    public Canvas inspectCanvas;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera.SetActive(true);
        inspectCamera.SetActive(false);
        inspectCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            playerCamera.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            inspectCamera.SetActive(true);
            inspectCanvas.gameObject.SetActive(true); 
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerCamera.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            inspectCamera.SetActive(false);
            inspectCanvas.gameObject.SetActive(false);
        }
    }

    
}
