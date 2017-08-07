using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlayerDiscCollider : MonoBehaviour {

    public GameObject killEffect;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(killEffect, other.gameObject.transform.position, Quaternion.identity);
            other.gameObject.GetComponent<PlayerDied>().decreaseLife();
            Destroy(other.gameObject);
        }
    }
}
