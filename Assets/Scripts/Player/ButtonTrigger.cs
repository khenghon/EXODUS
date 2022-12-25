using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonTrigger : MonoBehaviour
{
    private PlayerControls controls;
    public Camera playerCam;
    public float interactionRayDistance = 10f;
    public bool doorOpened = false;

    public GameObject Button;
    public GameObject Button1;
    public GameObject Move_door;
    public float maximumOpening = 2.51f;
    public float maximumClosing = -3.670279f;
    public float movementSpeed = 15f;
    void Awake()
    {
        controls = new PlayerControls();
    }
    void Update()
    {
        if (controls.Player.Interact.triggered)
        {
            //Debug.Log("E is pressed down");
            checkButtonPress();
        }

        if (doorOpened)
        {
            if (Move_door.transform.position.y <= maximumOpening)
            {
                Move_door.transform.Translate(0f, movementSpeed * Time.deltaTime, 0f);
            }
        }
        else
        {
            if (Move_door.transform.position.y >= maximumClosing)
            {
                Move_door.transform.Translate(0f, -movementSpeed * Time.deltaTime, 0f);
            }
        }
    }

    void checkButtonPress()
    {
        RaycastHit hit;
        Ray interactDoorRay = new Ray(playerCam.transform.position, playerCam.transform.forward);

        if (Physics.Raycast(interactDoorRay, out hit, interactionRayDistance))
        {
            //Debug.Log(hit.transform.name);

            if (hit.collider.gameObject.Equals(Button) || hit.collider.gameObject.Equals(Button1))
            {
                doorOpened = !doorOpened;
            }
        }
    }

    void MoveDoor()
    {
        if (doorOpened)
        {
            if (Move_door.transform.position.y <= maximumOpening)
            {
                Move_door.transform.Translate(0f, movementSpeed * Time.deltaTime, 0f);
            }
        }
        else
        {
            if (Move_door.transform.position.y >= maximumClosing)
            {
                Move_door.transform.Translate(0f, -movementSpeed * Time.deltaTime, 0f);
            }
        }
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
}
