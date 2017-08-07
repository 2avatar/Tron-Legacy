using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public Canvas quitMenu;
    public Button startButton;
    public Button ExitButton;
	// Use this for initialization
	void Start () {
        quitMenu.enabled = false;
	}


    /// exit action 
    public void ExitPress()
    {
        quitMenu.enabled = true;
        startButton.enabled = false;
        ExitButton.enabled = false;
    }

    // Quit menu No action
    public void NoPress()
    {
        quitMenu.enabled = false;
        startButton.enabled = true;
        ExitButton.enabled = true;
    }
	
    //Start pressed
	public void StartLevel()
    {
        SceneManager.LoadScene(1);
    }

    //Exit Menu yes pressed
    public void ExitGame()
    {
        Application.Quit();
    }

}
