using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    public GameObject knife;

	// Use this for initialization
	void Start () 
    {
        CreateKnife();
	}
	
	// Update is called once per frame
	void Update () 
    {
            
	}

    public void CreateKnife()
    {
        // Create knife if Trunk is alive!
        if(GameObject.Find("Trunk").GetComponent<TrunkHealth>().health > 1)
            Instantiate(knife, transform.position, Quaternion.identity);
    }
}
