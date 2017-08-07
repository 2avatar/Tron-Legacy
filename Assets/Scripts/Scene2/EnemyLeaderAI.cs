using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLeaderAI : MonoBehaviour {

    public Transform[] WayPoints;

    public float moveSpeed = 6;
    public float rotationSpeed = 1;
  
    private Vector3 direction;

    int currentWayPoint;
    bool onABreak = true;
    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //currentWayPoint = ++currentWayPoint % WayPoints.Length;
        GetComponent<Animator>().Play("WalkForward");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
                Idle();  
    }

    private void Idle()
    {
        direction = WayPoints[currentWayPoint].position - transform.position;
        direction.y = 0;
        int rotationWayPoint = 5;

        if (direction.magnitude < 1 && onABreak)
        {
            currentWayPoint = ++currentWayPoint % WayPoints.Length;
            StartCoroutine(stay());
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationWayPoint * Time.deltaTime);
        rb.velocity = direction.normalized * moveSpeed * Time.deltaTime;
    }

    private IEnumerator stay()
    {
        onABreak = false;
        yield return new WaitForSeconds(10);
        onABreak = true;
    }
}
