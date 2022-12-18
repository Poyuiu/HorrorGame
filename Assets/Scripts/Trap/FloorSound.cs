using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSound : MonoBehaviour {


    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            this.gameObject.GetComponent<AudioSource>().Play();
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            Destroy(this.gameObject, 2f);
        }

    }
}
