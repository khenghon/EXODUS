using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabListener : MonoBehaviour
{
    [SerializeField] Transform finalPosition;
    [SerializeField] float speed = 2.0f;
    [SerializeField] float rotationSpeed = 10.0f;

    Vector3 originalPosition;
    Quaternion originalRotation;
    GameObject m_objectGrabbed;

    public void ObjectGrabbed(GameObject objectGrabbed)
    {
        this.m_objectGrabbed = objectGrabbed;

        this.originalPosition = this.m_objectGrabbed.transform.position;
        this.originalRotation = this.m_objectGrabbed.transform.rotation;

        this.StopCoroutine("ReturnObjectBackPosition");
        this.StopCoroutine("ReturnObjectBackRotation");

        this.StartCoroutine("BringObjectForwardPosition");
        this.StartCoroutine("BringObjectForwardRotation");
    }

    public void ObjectDropped(GameObject objectDropped)
    {
        this.StopCoroutine("BringObjectForwardPosition");
        this.StopCoroutine("BringObjectForwardRotation");

        this.StartCoroutine("ReturnObjectBackPosition");
        this.StartCoroutine("ReturnObjectBackRotation");
    }

    IEnumerator BringObjectForwardPosition()
    {
        while (this.m_objectGrabbed.transform.position != this.finalPosition.position)
        {
            this.m_objectGrabbed.transform.position = Vector3.MoveTowards(this.m_objectGrabbed.transform.position, this.finalPosition.position, this.speed * Time.deltaTime);

            yield return null;
        }
    }

    IEnumerator BringObjectForwardRotation()
    {
        while (this.m_objectGrabbed.transform.rotation != this.finalPosition.rotation)
        {
            this.m_objectGrabbed.transform.rotation = Quaternion.RotateTowards(this.m_objectGrabbed.transform.rotation, this.finalPosition.rotation, this.rotationSpeed * Time.deltaTime);

            yield return null;
        }
    }

    IEnumerator ReturnObjectBackPosition()
    {
        while (this.m_objectGrabbed.transform.position != this.originalPosition)
        {
            this.m_objectGrabbed.transform.position = Vector3.MoveTowards(this.m_objectGrabbed.transform.position, this.originalPosition, this.speed * Time.deltaTime);

            yield return null;
        }
    }

    IEnumerator ReturnObjectBackRotation()
    {
        while (this.m_objectGrabbed.transform.rotation != this.originalRotation)
        {
            this.m_objectGrabbed.transform.rotation = Quaternion.RotateTowards(this.m_objectGrabbed.transform.rotation, this.originalRotation, this.rotationSpeed * Time.deltaTime);

            yield return null;
        }
    }
}


if