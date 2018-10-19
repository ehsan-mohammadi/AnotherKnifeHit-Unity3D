using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkRotate : MonoBehaviour {

    public float speed = -1.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        // Rotate Trunk in Z axis
        transform.Rotate(new Vector3(0, 0, speed));
	}
}
