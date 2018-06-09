using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody rb;
    public Animator a;
    public float thrust = 10, torque = 10;
    public AudioSource audioSource;
    public AudioClip slide, rotation, get;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.UpArrow)) {
            a.Play("Front");
            rb.AddForce(-transform.forward * thrust * ((Main.itemCount + 1) * 0.5f));
            audioSource.clip = slide;
            audioSource.Play();
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)) {
            a.Play("Back");
            rb.AddForce(transform.forward * thrust);
            audioSource.clip = slide;
            audioSource.Play();
        }
        if(Input.GetKey(KeyCode.LeftArrow)) {
            a.Play("Left");
            rb.AddTorque(-transform.up * torque * ((Main.itemCount + 1) * 0.5f));
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow)) {
            audioSource.clip = rotation;
            audioSource.Play();
        }
        if(Input.GetKey(KeyCode.RightArrow)) {
            a.Play("Right");
            rb.AddTorque(transform.up * torque);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)) {
            audioSource.clip = rotation;
            audioSource.Play();
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "GameOverArea") {
            Destroy(gameObject);
            Main.gameState = GameState.Over;
        }
        if(other.tag == "Item") {
            Destroy(other.gameObject);
            Main.itemCount++;
            rb.mass *= 0.8f;

            audioSource.clip = get;
            audioSource.Play();
        }
    }

}
