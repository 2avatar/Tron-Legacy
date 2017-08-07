using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCameraScript : MonoBehaviour {

    public GameObject motor;
    public GameObject motorCamera;
    public GameObject playerFPS;
    public GameObject playerStartPosition;
    public GameObject text;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //control boat
        if (Input.GetKey("1"))
        {
            changeToMotor();
            Destroy(text);
        }
        if (Input.GetKey("2"))
        {
           // changeToPlayer();
        }
    }

    void changeToPlayer()
    {
        motor.GetComponent<Rigidbody>().isKinematic = true;
        //motor.GetComponent<MotorScript>().enabled = false;
        motorCamera.SetActive(false);
        playerFPS.SetActive(true);
        playerFPS.transform.position = playerStartPosition.transform.position;
    }
    void changeToMotor()
    {
        motor.GetComponent<Rigidbody>().isKinematic = false;
        //motor.GetComponent<MotorScript>().enabled = true;
        motorCamera.SetActive(true);
        playerFPS.SetActive(false);
    }
}
