using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour {

    // Movement keys (customizable in Inspector)
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode rightKey;
    public KeyCode leftKey;

    // Movement Speed
    public float speed = 16;

    // Wall Prefab
    public GameObject wallPrefab;

    // Current Wall
    Collider2D wall;

    Vector2 lastWallEnd;

    public AudioClip beep;
    public AudioClip deathSound;

    public Canvas winAnnouncement;
    public Text text;

    public GameObject pointManager;

    void OnGUI()
    {
  
        GUI.Label(new Rect(600, 10, 300, 40), "Goal: Block your friend. Best of you out of 3 will play the next levels");
        GUI.Label(new Rect(320, 100, 200, 20), "Cyan Buttons: W, A, S, D");
        GUI.Label(new Rect(1400, 100, 300, 20), "Pink Buttons: Arrows: Up, Down, Left, Right");
    }


    // Use this for initialization
    void Start () {
        winAnnouncement.enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        spawnWall();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(upKey))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
            spawnWall();
            playBeep();
        }
        else if (Input.GetKeyDown(downKey))
        {
            GetComponent<Rigidbody2D>().velocity = -Vector2.up * speed;
            spawnWall();
            playBeep();
        }
        else if (Input.GetKeyDown(rightKey))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
            spawnWall();
            playBeep();
        }
        else if (Input.GetKeyDown(leftKey))
        {
            GetComponent<Rigidbody2D>().velocity = -Vector2.right * speed;
            spawnWall();
            playBeep();
        }

        fitColliderBetween(wall, lastWallEnd, transform.position);

        if (pointManager.GetComponent<PointManager>().gameOver)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    void playBeep()
    {
        AudioSource.PlayClipAtPoint(beep, Vector3.zero);
    }

    void spawnWall()
    {
       
        // Save last wall's position
        lastWallEnd = transform.position;

        // Spawn a new Lightwall
        GameObject g = (GameObject)Instantiate(wallPrefab, transform.position, Quaternion.identity);
        wall = g.GetComponent<Collider2D>();
    }

    void fitColliderBetween(Collider2D co, Vector2 a, Vector2 b)
    {
        // Calculate the Center Position
        co.transform.position = a + (b - a) * 0.5f;

        // Scale it (horizontally or vertically)
        float dist = Vector2.Distance(a, b);
        if (a.x != b.x)
            co.transform.localScale = new Vector2(dist+1, 1);
        else
            co.transform.localScale = new Vector2(1, dist+1);
    }

    void OnTriggerEnter2D(Collider2D co)
    {       
        // Not the current wall?
        if (co != wall)
        {
            if (name == "player_cyan")
                pointManager.GetComponent<PointManager>().increasePink();
            if (name == "player_pink")
                pointManager.GetComponent<PointManager>().increaseCyan();

            if (pointManager.GetComponent<PointManager>().gameOver)
            {
                AudioSource.PlayClipAtPoint(deathSound, Vector3.zero);
                Destroy(gameObject);
                winAnnouncement.enabled = true;
                text.text = "Player lost: " + name;
            }
            else
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

 

}
