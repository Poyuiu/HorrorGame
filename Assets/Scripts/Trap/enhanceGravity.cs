using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enhanceGravity : MonoBehaviour {
	private Vector3 originGravity;
	void Start() {
		this.originGravity = Physics.gravity;
	}
    void Update() {
        
    }
	void OnTriggerEnter(Collider other) {
		if (other.tag == "PlayerFake")
			Physics.gravity = Vector3.Scale(Physics.gravity, new Vector3(1, 2, 1));
	}
	void OnTriggerExit(Collider other) {
		if (other.tag == "PlayerFake"){
			Physics.gravity = this.originGravity;
            Debug.Log("++++");
        }
	}
}
