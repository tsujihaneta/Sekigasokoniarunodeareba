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
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) {
            a.Play("Front");
            Vector3 v = transform.forward * (thrust + Main.itemCount * 10);
            v *= -1;
            rb.AddForce(v);
            audioSource.clip = slide;
            audioSource.Play();
        }
        if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) {
            a.Play("Back");
            Vector3 v = transform.forward * (thrust + Main.itemCount * 10);
            rb.AddForce(v);
            audioSource.clip = slide;
            audioSource.Play();
        }
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
            a.Play("Left");
            Vector3 v = transform.up * (torque + Main.itemCount * 10);
            v *= -1;
            rb.AddTorque(v);
        }
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            a.Play("Right");
            Vector3 v = transform.up * (torque + Main.itemCount * 10);
            rb.AddTorque(v);
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) {
            a.Play("LeftStart");
            audioSource.clip = rotation;
            audioSource.Play();
        }
        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) {
            a.Play("RightStart");
            audioSource.clip = rotation;
            audioSource.Play();
        }

        if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A)) {
            a.Play("Default");
        }
        if(Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D)) {
            a.Play("Default");
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
            rb.mass *= 0.9f;

            audioSource.clip = get;
            audioSource.Play();
        }
    }

}
