using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour {

    public float speed = 20f;
    public AudioClip hitSound;
    Rigidbody2D knifeRigid;
    bool moving = false;

    GameObject spawn;

	// Use this for initialization
	void Start () 
    {
        // Identify Rigidbody
        knifeRigid = GetComponent<Rigidbody2D>();

        spawn = GameObject.Find("Spawn");
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        if(moving)
            knifeRigid.MovePosition(knifeRigid.position + Vector2.up * speed * Time.deltaTime);

        // Knife start moving after click
        if (Input.GetMouseButtonDown(0))
            moving = true;
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Stop knife moving, rotate with Trunk and play hit sound
        moving = false;
        transform.parent = collider.transform;
        GetComponent<AudioSource>().PlayOneShot(hitSound);
        spawn.GetComponent<SpawnController>().CreateKnife();
        collider.GetComponent<Animator>().SetTrigger("Hit");
        collider.GetComponent<TrunkHealth>().Damage(1);
        GetComponent<Knife>().enabled = false;
    }
}
