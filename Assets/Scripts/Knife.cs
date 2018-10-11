using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour {

    public float speed = 20f;
    public AudioClip hitSound;
    Rigidbody2D knifeRigid;
    bool moving = true;

	// Use this for initialization
	void Start () 
    {
        // Identify Rigidbody
        knifeRigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        if(moving)
            knifeRigid.MovePosition(knifeRigid.position + Vector2.up * speed * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Stop knife moving, rotate with Trunk and play hit sound
        moving = false;
        transform.parent = collider.transform;
        GetComponent<AudioSource>().PlayOneShot(hitSound);
    }
}
