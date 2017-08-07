using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeKillManager : MonoBehaviour {

    public Canvas loseAnnouncement;
    public Canvas winnerAnnouncement;
    public int numOfKillsLeft = 6;
    public int numOfPoints = 0;
    public bool playerDied;

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 300, 20), "Number of Enemys: " + numOfKillsLeft);
        GUI.Label(new Rect(10, 30, 300, 20), "Number of Points: " + numOfPoints);
    }
    // Use this for initialization
    void Start () {
        winnerAnnouncement.enabled = false;
        loseAnnouncement.enabled = false;
}
	
	// Update is called once per frame
	void Update () {
		
        if (numOfKillsLeft == 0 && !winnerAnnouncement.enabled)
            winnerAnnouncement.enabled = true;
        if (playerDied && !loseAnnouncement.enabled)
            loseAnnouncement.enabled = true;
     
	}
}
