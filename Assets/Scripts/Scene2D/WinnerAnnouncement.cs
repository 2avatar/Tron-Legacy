using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinnerAnnouncement : MonoBehaviour {

    public int sceneLevel;
	// Use this for initialization
	void Start () {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void FixedUpdate()
    {
       
    }
    //Start pressed
    public void NextLevel()
    {
        SceneManager.LoadScene(sceneLevel);
    }

    //Exit Menu yes pressed
    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }

}
