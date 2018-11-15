using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Knife : MonoBehaviour {

    public float speed = 20f;
    public AudioClip hitSound;
    public AudioClip fail;
    Rigidbody2D knifeRigid;
    bool moving = false;

    GameObject spawn;
    public GameObject particle;

    private bool scriptEnabled = true;

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
        if(scriptEnabled)
        {
            if (collider.name == "Trunk")
            {
                // Stop knife moving, rotate with Trunk and play hit sound
                moving = false;
                transform.parent = collider.transform;
                GetComponent<PolygonCollider2D>().enabled = false;
                knifeRigid.bodyType = RigidbodyType2D.Kinematic;
                transform.GetChild(0).GetComponent<PolygonCollider2D>().enabled = true;
                GetComponent<AudioSource>().PlayOneShot(hitSound);
                spawn.GetComponent<SpawnController>().CreateKnife();
                collider.GetComponent<Animator>().SetTrigger("Hit");
                collider.GetComponent<TrunkHealth>().Damage(1);

                Instantiate(particle, transform.position + transform.up * 0.25f, Quaternion.identity);

                GameController.SetScore(10);
            }
            else
            {
                // If hit to another knives
                moving = false;
                knifeRigid.bodyType = RigidbodyType2D.Dynamic;
                GetComponent<AudioSource>().PlayOneShot(fail);
                GameObject.Find("TextMessage").GetComponent<Text>().text = "GAME OVER";
                GameController.SaveHighScore();
                GameController.ResetScore();
                StartCoroutine(GoToLevel1());
            }

            scriptEnabled = false;
            GetComponent<Knife>().enabled = false;
        }
    }

    IEnumerator GoToLevel1()
    {
        // Go to level 1 after 2 seconds
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Level1");
    }
}
