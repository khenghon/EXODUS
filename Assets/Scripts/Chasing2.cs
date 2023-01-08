using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing2 : MonoBehaviour
{
    public Transform target; //the enemy's target
    public float moveSpeed = 3; //move speed
    public float rotationSpeed = 3; //speed of turning
    public float range = 10f; //Range wit$$anonymous$$n target will be detected
    public float stop = 0;
    public Transform myTransform; //current transform data of t$$anonymous$$s enemy
    void Awake()
    {
        target = GameObject.FindWithTag("Player").transform; //target the player
        myTransform = transform; //cache transform data for easy access/preformance
    }
    void Update()
    {    //rotate to look at the player
        float distance = Vector3.Distance(myTransform.position, target.position);
        if (distance <= range)
        {
            //look
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation,Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
            //move
            if (distance > stop)
            {
                myTransform.position -= myTransform.forward * -moveSpeed * Time.deltaTime;
            }
        }
    }
}
