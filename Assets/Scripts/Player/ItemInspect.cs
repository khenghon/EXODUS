using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ItemInspect : MonoBehaviour, IDragHandler
{
    private PlayerControls controls;
    public Camera playerCam;
    public float inspectRayDistance = 10f;
    public float distranceToCamera = 1f;
    public bool inInspection = false;
    public float speed;
    public GameObject inspestPosition;

    private GameObject objectInspected = null;
    private PlayerController playerController;
    private MouseLook mouseLook;
    private Vector3 originPosition;

    private void Awake()
    {
        controls = new PlayerControls();

        playerController = this.GetComponent<PlayerController>();
        mouseLook = this.gameObject.transform.GetChild(0).GetComponent<MouseLook>();
    }
    void Update()
    {
        if (controls.Player.Interact.triggered)
        {
            Debug.Log("E is pressed down");
            objectInspected = getObject();
            if (objectInspected.tag == "InspectableItem")
            {
                inInspection = !inInspection;
                Debug.Log("From " + !inInspection + " to " + inInspection);

            }
        }
        if (objectInspected != null)
        {
            if (objectInspected.tag == "InspectableItem" && inInspection)
            {
                Debug.Log("INSPECTION TIME");

                playerController.enabled = false;
                mouseLook.enabled = false;

                Cursor.lockState = CursorLockMode.None;
                //Rigidbody rb = objectInspected.GetComponent<Rigidbody>();
                //rb.useGravity = false;

                Vector3 a = objectInspected.transform.parent.position;
                Vector3 b = inspestPosition.transform.position;
                if (a != b)
                {
                    objectInspected.transform.parent.position = Vector3.MoveTowards(a, b, speed * Time.deltaTime);
                }
            }
            else if (objectInspected.tag == "InspectableItem")
            {
                Cursor.lockState = CursorLockMode.Locked;

                Vector3 a = objectInspected.transform.parent.position;
                if (a != originPosition)
                {
                    objectInspected.transform.parent.position = Vector3.MoveTowards(a, originPosition, speed * Time.deltaTime);
                }
                else
                {
                    playerController.enabled = true;
                    mouseLook.enabled = true;

                    //Rigidbody rb = objectInspected.GetComponent<Rigidbody>();
                    //rb.useGravity = true;
                }
            }
        }
    }
    GameObject getObject()
    {
        RaycastHit hit;
        Ray inspectRay = new Ray(playerCam.transform.position, playerCam.transform.forward);

        if (Physics.Raycast(inspectRay, out hit, inspectRayDistance))
        {
            Debug.Log("Inspecting: " + hit.transform.name);
        }
        if (!inInspection)
        {
            originPosition = hit.collider.gameObject.transform.parent.position;
            if (hit.collider.gameObject.tag == "InspectableItem")
            {
                this.gameObject.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
            hit.collider.gameObject.GetComponent<InspectRotator>().enabled = true;
        }
        else
        {
            this.gameObject.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.SetActive(false);
            hit.collider.gameObject.GetComponent<InspectRotator>().enabled = false;
        }
        return hit.collider.gameObject;
    }

    public void OnDrag(PointerEventData eventData)
    {
        objectInspected.transform.eulerAngles += new Vector3(-eventData.delta.y, -eventData.delta.x);
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
