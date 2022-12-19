using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSound : MonoBehaviour {

	private GameObject player;
	void Start() {
		this.player = GameObject.Find("FPSController");
	}
	void OnTriggerEnter(Collider other) {
		if (other.tag == "PlayerFake") {
			this.gameObject.GetComponent<AudioSource>().Play();
			this.gameObject.GetComponent<BoxCollider>().enabled = false;
			this.player.GetComponent<CharacterController>().enabled = false;
            this.player.GetComponent<Rigidbody>().velocity = Vector3.down;
			Invoke("ccResume", 0.3f);
			Destroy(this.gameObject, 2f);
		}
	}
	void ccResume() => this.player.GetComponent<CharacterController>().enabled = true;
}
