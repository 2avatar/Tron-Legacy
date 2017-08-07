using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootDisc : MonoBehaviour {

    public float discSpeed = 80f;
    public GameObject disc;
    public bool isFunctionable = false;
    public AudioClip discSound;

    // Use this for initialization
    void Start () {

        disc.GetComponent<BoxCollider>().isTrigger = false;

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.F) && isFunctionable)
        {
            AudioSource.PlayClipAtPoint(discSound, transform.position);
            GameObject rockets = Instantiate(disc, new Vector3(transform.position.x + transform.forward.x, 1, transform.position.z + transform.forward.z), transform.rotation);
            rockets.GetComponent<Rigidbody>().velocity = transform.forward * discSpeed;
            Destroy(rockets.gameObject, 2f);
        }

        }
}
