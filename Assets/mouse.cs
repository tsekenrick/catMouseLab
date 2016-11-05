using UnityEngine;
using System.Collections;

public class mouse : MonoBehaviour {
    AudioSource source;
    Vector3 directionToCat;
    public Transform cat;
    Rigidbody rb;
    public bool hasPlayed;
    float playTimer;
    // Use this for initialization
    void Start () {
        directionToCat = cat.position - transform.position;
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
        
	}
	
	// Update is called once per frame
	void Update () {
    if (hasPlayed == true)
        {
            playTimer += Time.deltaTime;
        }
	
    if (playTimer >= 5)
        {
            hasPlayed = false;
            playTimer = 0;
        }
	}

    void FixedUpdate()
    {
        directionToCat = cat.position - transform.position;
        if (Vector3.Angle(transform.forward, directionToCat) < 165f)
        {
            Ray mouseRay = new Ray(transform.position, directionToCat);
            Debug.DrawRay(transform.position, directionToCat, Color.yellow);
            RaycastHit mouseRayHitInfo;
            if (Physics.Raycast(mouseRay, out mouseRayHitInfo, 50f))
            {               
                if (mouseRayHitInfo.collider.tag == "Cat")
                {
                    if (hasPlayed == false)
                    {
                        source.Play();
                        hasPlayed = true;
                    }
                    Debug.Log("running!");
                    rb.AddForce(-directionToCat.normalized * 1250f);
                }
                
            }
        }
    }
}
