using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomMove : MonoBehaviour
{
    public Transform[] points;
    private NavMeshAgent agent;
    private Vector3 agentPosition;

    private Vector3 leftWall;
    private Vector3 rightWall;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        leftWall = points[0].GetComponent<Transform>().position;
        rightWall = points[1].GetComponent<Transform>().position;
        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = true;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        agentPosition = agent.GetComponent<Transform>().transform.position;

        Vector3 destination = new Vector3(agentPosition.x,
            agentPosition.y, 
            Random.Range(leftWall.z, rightWall.z)
            );
        Debug.Log(destination);
        // Set the agent to go to the currently selected destination.
        agent.destination = destination;
    }


    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 5f)
            GotoNextPoint();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
            agent.Stop();
    }
}
