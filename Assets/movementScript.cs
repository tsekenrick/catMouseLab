using UnityEngine;
using System.Collections;

public class movementScript : MonoBehaviour {

    // Use this for initialization
    public float moveSpeed;
    float randInt;
    Rigidbody rb;
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {   
        rb.velocity = rb.transform.forward * moveSpeed + Physics.gravity;
        Ray moveRay = new Ray(rb.transform.position, rb.transform.forward);
        Debug.DrawRay(moveRay.origin, moveRay.direction, Color.red);
        randInt = Random.value;
        if (Physics.SphereCast(moveRay, .25f, 1.1f))
        {   
            
            if (randInt < .5f)
            {

                transform.Rotate(0f, 90, 0f);
            }
            else if (randInt < 1.0f)
            {
                transform.Rotate(0f, -90, 0f);
            }
           
        }
    }
}
