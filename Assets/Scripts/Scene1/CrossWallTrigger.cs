using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossWallTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetType() == typeof(BoxCollider))
        other.gameObject.transform.position = new Vector3(0,2,0);
    }
}
