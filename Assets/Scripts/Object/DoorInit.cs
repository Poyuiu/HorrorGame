using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInit : MonoBehaviour {
	[SerializeField] private int passSavePoint;
	[SerializeField] private float direction;

	void Start() {
		if (GameObject.Find("FPSController").GetComponent<PlayerSave>().nowSP >= passSavePoint)
			this.transform.Rotate(new Vector3(0f, 75f * direction, 0f));
	}


}
