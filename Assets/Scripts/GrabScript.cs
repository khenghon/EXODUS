using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabScript : MonoBehaviour
{
    [SerializeField] Transform origin; // Use this if you want to specify where you want the raycast to start firing. If not it will default to the Camera.
    [SerializeField] float raycastDistance; // The distance the ray cast will go from the origin/camera point.
    [SerializeField] ObjectGrabbedEvent onObjectGrabbed; // Events you can use to register when an object is grabbed.
    [SerializeField] ObjectDroppedEvent onObjectDropped; // Events you can use to register when an object is dropped.
    [SerializeField] KeyCode grabObject; // Hard coded keycode for grabbing an object.
    [SerializeField] LayerMask grabableObjectLayer;

    GameObject m_objectGrabbed;

    void Update()
    {
        if (Input.GetKeyDown(this.grabObject))
        {
            RaycastHit hit;

            if (Physics.Raycast(this.Origin.position, this.Origin.forward, out hit, this.raycastDistance, this.grabableObjectLayer))
            {
                this.m_objectGrabbed = hit.collider.gameObject;

                this.onObjectGrabbed.Invoke(this.m_objectGrabbed);
            }
        }

        if (Input.GetKeyUp(this.grabObject))
        {
            if (this.m_objectGrabbed != null)
            {
                this.onObjectDropped.Invoke(this.m_objectGrabbed);

                this.m_objectGrabbed = null;
            }
        }
    }

    protected Transform Origin
    {
        get
        {
            if (this.origin == null)
            {
                return Camera.main.transform;
            }
            else
            {
                return this.origin;
            }
        }
    }

    public ObjectGrabbedEvent ObjectGrabbedEvent
    {
        get
        {
            return this.onObjectGrabbed;
        }
        set
        {
            this.onObjectGrabbed = value;
        }
    }

    public ObjectDroppedEvent ObjectDroppedEvent
    {
        get
        {
            return this.onObjectDropped;
        }
        set
        {
            this.onObjectDropped = value;
        }
    }
}
