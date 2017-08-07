using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectIdentification : MonoBehaviour {

    public AudioClip beep;
    public GameObject targetBlow;
    RaycastHit hit;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        Vector3 fixPosition = transform.position;
        fixPosition.y = 1;

        Debug.DrawRay(fixPosition, transform.forward * 10, Color.red);
        if (Physics.Raycast(fixPosition, transform.forward, out hit, 10))
            {
            if (hit.collider.GetType() == typeof(BoxCollider)) 
            AudioSource.PlayClipAtPoint(beep, transform.position);
            Debug.DrawRay(fixPosition, transform.forward * hit.distance, Color.green);
            if (Physics.Raycast(fixPosition, transform.forward, out hit, hit.distance))
            {
                if (hit.collider.gameObject.tag == "Player")
                {

                    Instantiate(targetBlow, hit.collider.gameObject.transform.position, hit.collider.gameObject.transform.rotation);
                    hit.collider.gameObject.GetComponent<PlayerDied>().decreaseLife();
                    Destroy(hit.collider.gameObject);

                }
            }
            }
        }
}
