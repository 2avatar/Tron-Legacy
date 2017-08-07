using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulCollectorAnimation : MonoBehaviour {

    public GameObject manSouls;
    public GameObject teleport;

    private int soulFreed = 0;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void freeSouls()
    {
        Instantiate(manSouls, transform.position, Quaternion.identity);
        soulFreed++;

        if (soulFreed == 9)
            Instantiate(teleport, teleport.transform.position, teleport.transform.rotation);
    }
}
