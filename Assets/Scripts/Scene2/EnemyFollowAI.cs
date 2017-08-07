using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowAI : MonoBehaviour {

    public GameObject followTarget;

    public float contactDistance = 3;

    NavMeshAgent agent;

    //bool onABreak = true;
    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GetComponent<Animator>().Play("WalkForward");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        NavAgent();      
    }


    private void NavAgent()
    {
        Vector3 distanceVector = followTarget.transform.position - transform.position;
        if (distanceVector.magnitude > contactDistance)
        agent.SetDestination(followTarget.transform.position);
    }
}
