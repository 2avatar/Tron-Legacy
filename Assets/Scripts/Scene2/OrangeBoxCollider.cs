using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeBoxCollider : MonoBehaviour {

    public GameObject boxRemain;
    public AudioClip boxExplode;
    public int counter = 0;
    public int maxCounter = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Disc")
        {
            counter++;
            Destroy(collision.gameObject);
            if (counter == maxCounter)
            {
                AudioSource.PlayClipAtPoint(boxExplode, transform.position);
                Instantiate(boxRemain, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
