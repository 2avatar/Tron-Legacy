using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCollider : MonoBehaviour {

    // Use this for initialization
    public string targetTag;
    public GameObject targetRemain;

    void Start () {
      
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetType() == typeof(BoxCollider))
        {
            if (other.gameObject.tag == targetTag)
            {
                Vector3 position = other.gameObject.transform.position;
                Quaternion rotation = other.gameObject.transform.rotation;
                GameObject manager = GameObject.Find("Manager");
                GameObject player = GameObject.Find("LightCycleBlue");

                Destroy(other.gameObject);
                Instantiate(targetRemain, position, rotation);

                if (other.gameObject.tag == "Enemy")
                {
                    if (player != null)
                    {
                        Vector3 distanceVector = player.transform.position - transform.position;
                        int factor = 50;

                        manager.GetComponent<LifeKillManager>().numOfKillsLeft--;
                        manager.GetComponent<LifeKillManager>().numOfPoints += (int)distanceVector.magnitude * factor;

                        if (manager.GetComponent<LifeKillManager>().numOfKillsLeft == 0)
                        player.GetComponent<LightCycleMoveScript>().accelerationSpeed = 0;
                    }
                }

                if (other.gameObject.tag == "Player")
                {
                    manager.GetComponent<LifeKillManager>().playerDied = true;
                }
            }
        }
    }

}
