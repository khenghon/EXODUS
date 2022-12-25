using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InspectRotator : MonoBehaviour, IDragHandler
{
    [SerializeField] float rotationSpeed = 100f;
    bool dragging = false;
    //Rigidbody rb;
    GameObject item;
    void Start()
    {
        //rb = GetComponent<Rigidbody>();

    }
    //void Update()
    //{
    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        dragging = false;
    //    }
    //}
    //private void FixedUpdate()
    //{
    //    if (dragging)
    //    {
    //        float x = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
    //        float y = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

    //        //rb.AddTorque(Vector3.down * x);
    //        //rb.AddTorque(Vector3.right * y);
    //    }
    //}
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        item.transform.eulerAngles += new Vector3(-eventData.delta.y, -eventData.delta.x);
    }
    //void OnMouseDrag()
    //{
    //    dragging = true;
    //}
}
