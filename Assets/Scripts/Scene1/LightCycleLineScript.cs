using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCycleLineScript : MonoBehaviour {

    public GameObject LineObject;
    public int LineLifeCycle = 5;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void FixedUpdate () {

        if (GetComponent<Rigidbody>().velocity.magnitude > 0.1)
        {
            GameObject boxColliders = Instantiate(LineObject, new Vector3(transform.position.x - transform.forward.x * 5 + 0.7f, 2, transform.position.z - transform.forward.z * 5), transform.rotation);
            Destroy(boxColliders, LineLifeCycle);
        }
    }
}
