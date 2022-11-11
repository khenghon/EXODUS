using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{
    public GameObject pickupobject;
    public GameObject activatingobject;

    public GameObject pickstuff;

    public bool OnReach;


    void OnactionPICK(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            OnReach = true;
            pickupstuff.SetActive(true);
        }
    }

    void Onactionleave(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            OnReach = false;
            pickupstuff.SetActive(false);
        }
    }


    void Update()
    {
        if(inReach && Input.GetButtonDown("Interact"))
        {
            pickupobject.SetActive(false);
            activatingobject.SetActive(true);
            pickupstuff.SetActive(false);
        }
        
    }
}