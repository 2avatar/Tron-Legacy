using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCycleShootDiscScript : MonoBehaviour {

    public float DiscSpeed = 80f;
    public GameObject EnemyBlow;
    public GameObject Disc;
    RaycastHit hit;

    // Use this for initialization
    void Start () {
        Disc.GetComponent<BoxCollider>().isTrigger = true;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        Debug.DrawRay(transform.position, transform.forward * 10, Color.red);
        if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject rockets = Instantiate(Disc, new Vector3(transform.position.x + transform.forward.x * 6 + 0.7f, 2, transform.position.z + transform.forward.z * 6), transform.rotation);
            rockets.GetComponent<Rigidbody>().velocity = transform.forward * DiscSpeed;
            Destroy(rockets.gameObject, 0.3f);
            if (Physics.Raycast(transform.position, transform.forward, out hit, 10))
            {
    
                if (hit.collider.gameObject.tag == "Enemy" && hit.collider.GetType() == typeof(BoxCollider))
                {
                    GameObject manager = GameObject.Find("Manager");
                    manager.GetComponent<LifeKillManager>().numOfKillsLeft--;
                    manager.GetComponent<LifeKillManager>().numOfPoints += 2000;

                    Instantiate(EnemyBlow, hit.collider.gameObject.transform.position, hit.collider.gameObject.transform.rotation);
                    Destroy(hit.collider.gameObject);
                    
                }
            }
        }

    }
}
