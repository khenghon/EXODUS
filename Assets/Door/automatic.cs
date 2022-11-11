using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class automatic : MonoBehaviour
{
    public GameObject Move_door;// Start is called before the first frame update

    public float maximumOpening = 2.56f;
    public float maximumClosing = 0;
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
        //var step = movementSpeed * Time.deltaTime;
        if (player_here)
        {
            if (Move_door.transform.position.y <= maximumOpening)
            {
                Move_door.transform.Translate(0f, movementSpeed * Time.deltaTime, 0f);
                //Move_door.transform.position = Vector3.MoveTowards(Move_door.transform.position, Move_door.transform.position + new Vector3(0f, maximumClosing - maximumOpening, 0f), step);
            }
        }
        else
        {
            if (Move_door.transform.position.y >= maximumClosing)
            {
                Move_door.transform.Translate(0f, -movementSpeed * Time.deltaTime, 0f);
                //Move_door.transform.position = Vector3.MoveTowards(Move_door.transform.position, Move_door.transform.position + new Vector3(0f, - maximumClosing - maximumOpening, 0f), step);
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
        