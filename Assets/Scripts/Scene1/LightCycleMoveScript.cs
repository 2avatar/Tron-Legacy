using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LightCycleMoveScript : MonoBehaviour {

    public float turnSpeed = 30f;
    public float accelerationSpeed = 1300f;
    private Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (Input.GetKey(KeyCode.O))
            SceneManager.LoadScene(3);

        float h = Input.GetAxis("Horizontal");

        rb.AddTorque(0, h * turnSpeed, 0);

        rb.velocity = transform.forward * accelerationSpeed * Time.deltaTime;
    }
}
