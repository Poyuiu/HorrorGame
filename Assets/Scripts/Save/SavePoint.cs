using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour {
	
	[SerializeField] private int sp;
	void OnTriggerEnter(Collider other) {
        if(other.tag=="Player")
            other.GetComponent<PlayerSave>().Save(sp);
	}
}
