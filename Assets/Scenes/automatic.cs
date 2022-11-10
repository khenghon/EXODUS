using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class automatic : MonoBehaviour
{
    public GameObject Move_door;// Start is called before the first frame update

    public float maximumOpening = 10f;
    public float maximumClosing = 0f;
    public float movementSpeed = 15f;

    bool player_here;
    bool opening;

    void Start()
    {
        player_here = false;
        opening = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player_here)
        {
            if (Move_door.transform.position.x < maximumOpening)
            {
                Move_door.transform.Translate(movementSpeed * Time.deltaTime, 0f, 0f);
            }
        }
        else
        {
            if (Move_door.transform.position.x > maximumClosing)
            {
                Move_door.transform.Translate(-movementSpeed * Time.deltaTime, 0f, 0f);
            }
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Enter");
            player_here = true;

        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Exit");
            player_here = false;
        }
    }
}
        