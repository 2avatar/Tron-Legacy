using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderAnimationScript : MonoBehaviour {

    public Transform destination;
    public GameObject blowEffect;
    public GameObject blowEffect2;
    public AudioClip soulTaker;
    public float lineDrawSpeed;

    private LineRenderer lineRenderer;
    private float counter;
    private float distance;
    private bool hasCollided = false;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {       
            if (counter < distance && hasCollided)
            {
                counter += .1f / lineDrawSpeed;
                float x = Mathf.Lerp(0, distance, counter);
                Vector3 PointA = transform.position; Vector3 PointB = destination.position;
                Vector3 pointAlongLine = x * Vector3.Normalize(PointB - PointA) + PointA;
                lineRenderer.SetPosition(1, pointAlongLine);
            }      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Disc")
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetWidth(.45f, .45f);
            lineRenderer.SetPosition(1, destination.position);
            distance = Vector3.Distance(transform.position, destination.position);

            if (!hasCollided)
            {
                AudioSource.PlayClipAtPoint(soulTaker, transform.position);
                Instantiate(blowEffect, transform.position, Quaternion.identity);
                Instantiate(blowEffect2, transform.position, Quaternion.identity);
                destination.GetComponent<SoulCollectorAnimation>().freeSouls();
            }
            hasCollided = true;
          
        }
    }













}
