using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInspect : MonoBehaviour
{
    public Camera playerCam;
    public float inspectRayDistance = 10f;
    public float distranceToCamera = 1f;
    public bool inInspection;
    public AnimationCurve curve;
    float elapsedTime;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F is pressed down");
            checkItemInspectable();
        }
    }

    void checkItemInspectable()
    {
        RaycastHit hit;
        Ray inspectRay = new Ray(playerCam.transform.position, playerCam.transform.forward);

        if (Physics.Raycast(inspectRay, out hit, inspectRayDistance))
        {
            Debug.Log(hit.transform.name);

            if (hit.collider.tag == "InspectableItem")
            {
                inspectItem(hit);
            }
        }
    }

    void inspectItem(RaycastHit hit)
    {
        GameObject item = hit.transform.gameObject;
        Vector3 originPosition = item.transform.position;
        Vector3 inspectPosition = playerCam.transform.position;
        float desiredDuration = 3f;

        elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / desiredDuration;

        item.transform.position = Vector3.Lerp(originPosition, inspectPosition, curve.Evaluate(percentageComplete));
    }
}
