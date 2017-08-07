using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MalenCollider : MonoBehaviour {

    public GameObject arrow;

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
            Destroy(gameObject, 2);
            arrow.GetComponent<Animator>().SetTrigger("threeToFour");
        }
    }
}
