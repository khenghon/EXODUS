using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public Camera playerCam;
    public float interactionRayDistance = 10f;
    public bool doorOpened = false;

    public GameObject Move_door;// Start is called before the first frame update
    public float maximumOpening = 2.51f;
    public float maximumClosing = -3.670279f;
    public float movementSpeed = 15f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F is pressed down");
            checkButtonPress();
        }
    }

    void checkButtonPress()
    {
        RaycastHit hit;
        Ray interactDoorRay = new Ray(playerCam.transform.position, playerCam.transform.forward);

        if (Physics.Raycast(interactDoorRay, out hit, interactionRayDistance))
        {
            Debug.Log(hit.transform.name);

            if (hit.collider.tag == "DoorButton")
            {
                MoveDoor();
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
}
