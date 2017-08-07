using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;


public class LifeManage : MonoBehaviour {

    public static int lifeCounter = 3;
    public int loseScene = 0;
    // Use this for initialization

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 20), "Lifes: " + lifeCounter); 
    }
    void Start () {
       

    }
	
	// Update is called once per frame
	void Update () {

        if (lifeCounter == 0) {
            lifeCounter = 3;
            SceneManager.LoadScene(loseScene);
        }
	}

    public void decreaseLife()
    {
        lifeCounter--;
        restartLevel();
    }

    public void restartLevel()
    {
        if (lifeCounter > 0)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    

}
