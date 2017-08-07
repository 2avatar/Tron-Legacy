using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PointChangeState : MonoBehaviour {

    public GameObject arrow;
    public string trigger;
    public GameObject text;

    private GameObject textHelper;
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
            arrow.GetComponent<Animator>().SetTrigger(trigger);
            textHelper = Instantiate(text, text.gameObject.transform.position, text.gameObject.transform.rotation);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(textHelper);
        }
    }
}
