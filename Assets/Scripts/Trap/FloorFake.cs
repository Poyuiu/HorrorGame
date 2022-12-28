using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorFake : MonoBehaviour {

	private GameObject player;
	void Start() {
		this.player = GameObject.Find("FPSController");
	}
	void OnTriggerEnter(Collider other) {
		if (other.tag == "PlayerFake") {
			this.gameObject.GetComponent<AudioSource>().Play();
			this.gameObject.GetComponent<BoxCollider>().enabled = false;
			this.player.GetComponent<CharacterController>().Move(Vector3.down * 2);
			Destroy(this.gameObject, 2f);
		}
	}

}
