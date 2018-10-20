using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkRotate : MonoBehaviour
{

    public float speed = -1.5f;
    public bool randomRotate = false;
    public float minSpeed = -1.5f;
    public float maxSpeed = -3f;
    public int timeRandom = 2;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Rotate Trunk in Z axis
        if (randomRotate)
        {
            transform.Rotate(new Vector3(0, 0, speed));
            StartCoroutine(randomSpeed());
        }
        else
            transform.Rotate(new Vector3(0, 0, speed));
    }

    IEnumerator randomSpeed()
    {
        yield return new WaitForSeconds(timeRandom);
        transform.Rotate(new Vector3(0, 0, Random.Range(minSpeed, maxSpeed)));
    }
}
