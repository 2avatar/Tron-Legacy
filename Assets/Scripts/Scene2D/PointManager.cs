using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour {

    static int numOfWinsPink = 0;
    static int numOfWinsCyan = 0;

    public bool gameOver = false;
    // Use this for initialization

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 20), "Pink number of wins:  " + numOfWinsPink);
        GUI.Label(new Rect(10, 30, 200, 20), "Cyan number of wins: " + numOfWinsCyan);
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    public void increasePink()
    {
        numOfWinsPink++;
        checkWin();
    }
    public void increaseCyan()
    {
        numOfWinsCyan++;
        checkWin();
    }

    public void checkWin()
    {
        if (numOfWinsCyan == 3 || numOfWinsPink == 3)
            gameOver = true;
    }

    public void resetWins()
    {
        numOfWinsPink = 0;
        numOfWinsCyan = 0;
    }
}
