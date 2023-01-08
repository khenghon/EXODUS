using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorGroup3 : MonoBehaviour
{
    public GameObject Move_door1;
    public GameObject Move_door2;
    public float maximumOpening1;
    public float maximumClosing1;
    public float maximumOpening2;
    public float maximumClosing2;
    private float movementSpeed = 15f;
    public bool doorOpened = false;

    // Update is called once per frame
    void Update()
    {
        if (doorOpened)
        {
            if (Move_door1.transform.position.x >= maximumOpening1)
            {
                Move_door1.transform.Translate(0f, 0f, movementSpeed * Time.deltaTime);
            }
            if (Move_door2.transform.position.x <= maximumOpening2)
            {
                Move_door2.transform.Translate(0f, 0f, -movementSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (Move_door1.transform.position.x <= maximumClosing1)
            {
                Move_door1.transform.Translate(0f, 0f, -movementSpeed * Time.deltaTime);
            }
            if (Move_door2.transform.position.x >= maximumClosing2)
            {
                Move_door2.transform.Translate(0f, 0f, movementSpeed * Time.deltaTime);
            }
        }
    }
}
