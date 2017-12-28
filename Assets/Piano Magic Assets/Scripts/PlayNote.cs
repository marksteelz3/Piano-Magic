using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayNote : MonoBehaviour {

    public float tempo;
    public Vector3 maxVel;

    private Rigidbody rb;
    private Collider playCol;

	void Awake () {
        rb = GetComponent<Rigidbody>();
        playCol = GetComponent<Collider>();
    }
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.isPlaying())
        {
            playCol.isTrigger = true;
            
            if (rb.velocity.magnitude >= maxVel.magnitude)
            {
                rb.velocity = maxVel;
                return;
            }
            
            rb.AddForce(new Vector3(0, 0, -tempo));
        }
        if (!GameManager.instance.isPlaying())
        {
            playCol.isTrigger = false;
            Vector3 zero = new Vector3(0, 0, 0);
            if (rb.velocity.magnitude == zero.magnitude)
            {
                rb.velocity = zero;
                return;
            }
            rb.AddForce(new Vector3(0, 0, tempo));
        }
    }
}
