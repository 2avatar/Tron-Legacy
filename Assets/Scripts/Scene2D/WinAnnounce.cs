using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinAnnounce : MonoBehaviour {
    
    public GameObject pointManager;
    public int sceneLevel;
    // Use this for initialization
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    //Start pressed
    public void NextLevel()
    {
        pointManager.GetComponent<PointManager>().resetWins();
        SceneManager.LoadScene(sceneLevel);
    }

    //Exit Menu yes pressed
    public void ExitGame()
    {
        pointManager.GetComponent<PointManager>().resetWins();
        SceneManager.LoadScene(0);
    }
}
