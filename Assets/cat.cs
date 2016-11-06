using UnityEngine;
using System.Collections;

public class cat : MonoBehaviour
{
    AudioSource[] sources;
    public Transform mouse;
    Rigidbody rb;
    public bool hasPlayed;
    public float playTimer;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sources = GetComponents<AudioSource>();
    }

    void Update()
    {
        if (hasPlayed == true)
        {
            playTimer += Time.deltaTime;
        }

        if (playTimer >= 3)
        {
            hasPlayed = false;
            playTimer = 0;
        }
    }


    void FixedUpdate()
    {
        if (mouse == null)
        {
            return;
        }
        Vector3 directionToMouse = mouse.position - transform.position;

        if (Vector3.Angle(transform.forward, directionToMouse) < 70f)
        {
            Ray catRay = new Ray(transform.position, directionToMouse);
            RaycastHit catRayHitInfo;
            if (Physics.Raycast(catRay, out catRayHitInfo, 7.5f))
            {
                if (catRayHitInfo.collider.tag == "Mouse")
                {
                    if (catRayHitInfo.distance <= 1.5f)
                    {
                        sources[0].Play();
                        Debug.Log("mouse caught");
                        Destroy(mouse.gameObject);

                    }
                    else
                    {
                        Debug.Log("chasing mouse");
                        rb.AddForce(directionToMouse.normalized * 1000f);
                        if (hasPlayed == false)
                        {
                            sources[1].Play();                            
                            hasPlayed = true;
                        }
                    }
                }
            }

        }
    }
}
