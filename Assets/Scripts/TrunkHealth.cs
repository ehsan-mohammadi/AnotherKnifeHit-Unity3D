using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrunkHealth : MonoBehaviour {

    public int health = 5;
    public AudioClip breakClip;
    public AudioClip startClip;

    void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(startClip);
    }

    void Update()
    {

    }

    // Decrease health
	public void Damage(int value)
    {
        health -= value;

        if (health == 0) // If there is no health
        {
            // Deactive Trunk collider
            GetComponent<CircleCollider2D>().enabled = false;

            // Trunk fragmentation
            // Fragmention 1
            transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
            transform.GetChild(0).GetComponent<Rigidbody>().AddForce(400, 800, 0);
            transform.GetChild(0).GetComponent<Rigidbody>().AddTorque(100, 100, 100);
            transform.GetChild(0).parent = null;
            // Fragmention 2
            transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
            transform.GetChild(0).GetComponent<Rigidbody>().AddForce(-400, 800, 0);
            transform.GetChild(0).GetComponent<Rigidbody>().AddTorque(-100, 100, 100);
            transform.GetChild(0).parent = null;
            // Fragmention 3
            transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
            transform.GetChild(0).GetComponent<Rigidbody>().AddForce(0, 800, 0);
            transform.GetChild(0).GetComponent<Rigidbody>().AddTorque(-200, 100, -100);
            transform.GetChild(0).parent = null;

            while (transform.childCount > 0)
            {
                // Knives apart from Trunk
                transform.GetChild(0).GetComponent<Rigidbody2D>().isKinematic = false;
                transform.GetChild(0).GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-400f, 400f), Random.Range(400f, 800f)));
                transform.GetChild(0).GetComponent<Rigidbody2D>().AddTorque(Random.Range(-400, 400));
                transform.GetChild(0).parent = null;
            }

            GetComponent<AudioSource>().PlayOneShot(breakClip);

            // Show "YOU WIN!" and go to next level
            GameObject.Find("TextMessage").GetComponent<Text>().text = "YOU WIN!";
            StartCoroutine(NextLevel());
        }
    }

    IEnumerator NextLevel()
    {
        // Go to next level after 2 seconds
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
