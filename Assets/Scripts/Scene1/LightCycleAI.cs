using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCycleAI : MonoBehaviour {

    public enum AIState { Idle, Flee, Evade }
    public AIState currentState;
    public AIState switchState;

    public Transform[] WayPoints;

    public Transform target;
    public float moveSpeed = 6;
    public float rotationSpeed = 1;

    private Vector3 direction;
   // private int safeDistance = 60;
  

    int currentWayPoint;
    //bool onABreak = true;
    Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        currentWayPoint = Random.Range(0, WayPoints.Length-1) % WayPoints.Length;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        switch (currentState)
        {
            case AIState.Idle:
                Idle();
                break;
            case AIState.Flee:
                Flee();
                break;
            case AIState.Evade:
                Evade();
                break;
        }
    }

    private void Idle()
    {
        direction = WayPoints[currentWayPoint].position - transform.position;
        direction.y = 0;
        int rotationWayPoint = 5;

        if (direction.magnitude < 1)
        {
            currentWayPoint = Random.Range(0, WayPoints.Length - 1) % WayPoints.Length;
            StartCoroutine(stay());
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationWayPoint * Time.deltaTime);
        rb.velocity = direction.normalized * moveSpeed * Time.deltaTime;
    }

    private IEnumerator stay()
    {
        //onABreak = false;
        yield return new WaitForSeconds(1);
        //onABreak = true;

    }

    private void Flee()
    {
        direction = transform.position - target.position;
        direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
        rb.velocity = direction.normalized * moveSpeed * Time.deltaTime;
    }

    private void Evade()
    {
        int iterationAhead = 10;
        Vector3 targetSpeed = target.gameObject.GetComponent<Rigidbody>().velocity;
        Vector3 targetFuturePosition = target.gameObject.transform.position + (targetSpeed * iterationAhead);
        direction = transform.position - targetFuturePosition;
        direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
        rb.velocity = direction.normalized * moveSpeed * Time.deltaTime;
            //Vector3 moveVector = direction.normalized * moveSpeed * Time.deltaTime;
            //transform.position += moveVector;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")          
            currentState = switchState;
        
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            currentState = AIState.Idle;
    
            
     
    }
}
