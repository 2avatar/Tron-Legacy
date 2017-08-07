using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscSlayerSound : MonoBehaviour {

    public AudioClip discSlide;
    public float x;
    public float y;
    public float z;
    bool state = true;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.rotation.x > 150 && state)
        {
            state = false;
            AudioSource.PlayClipAtPoint(discSlide, new Vector3(x,y,z));
        }
        if (transform.rotation.x < 150 && !state)
        {
            state = true;
            AudioSource.PlayClipAtPoint(discSlide, transform.position);
        }
    }
}
