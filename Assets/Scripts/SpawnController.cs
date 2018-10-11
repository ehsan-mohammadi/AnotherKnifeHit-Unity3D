using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    public GameObject knife;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        // If left click or touch, create new knife game object
        if (Input.GetMouseButtonDown(0))
            Instantiate(knife, transform.position, Quaternion.identity);
	}
}
