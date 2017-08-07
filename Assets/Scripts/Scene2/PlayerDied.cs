using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDied : MonoBehaviour {

    public GameObject lifeManager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.O))
            SceneManager.LoadScene(4);
        if (Input.GetKey(KeyCode.P))
            SceneManager.LoadScene(5);

    }

    public void decreaseLife()
    {
        lifeManager.GetComponent<LifeManage>().decreaseLife();
    }
    
}
