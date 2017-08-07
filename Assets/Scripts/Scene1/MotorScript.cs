using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorScript : MonoBehaviour {

    public float turnSpeed = 100f;
    public float accelerationSpeed = 100f;
    public float rocketSpeed = 1000f;
    private Rigidbody rg;
    RaycastHit hit;
    public Transform rocket;
    public GameObject remain;
    public GameObject LineCycle;
    public int LineLifeCycle = 5;
    // Use this for initialization
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");

        rg.AddTorque(0, h * turnSpeed, 0);

        rg.velocity = transform.forward * accelerationSpeed * Time.deltaTime;

        Debug.DrawRay(transform.position, transform.forward * 10, Color.red);
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Mouse Down");

            Transform rockets = Instantiate(rocket, new Vector3(transform.position.x+transform.forward.x*6 + 0.7f, 2, transform.position.z+transform.forward.z*6), transform.rotation);
            rockets.GetComponent<Rigidbody>().velocity = transform.forward * rocketSpeed;
            Destroy(rockets.gameObject, 0.5f);
            if (Physics.Raycast(transform.position, transform.forward, out hit, 10))
            {
                Debug.Log("Hit");
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    Instantiate(remain, hit.collider.gameObject.transform.position, hit.collider.gameObject.transform.rotation);
                    Destroy(hit.collider.gameObject);
                    Debug.Log(hit.distance);
                }
            }
        }

        GameObject boxColliders = Instantiate(LineCycle, new Vector3(transform.position.x - transform.forward.x * 5 + 0.7f, 2, transform.position.z - transform.forward.z * 5), transform.rotation);
        Destroy(boxColliders, LineLifeCycle);

    }
}
