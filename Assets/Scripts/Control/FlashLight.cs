using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour {
	[SerializeField] private GameObject mLight;
	void Update() {
		if (Input.GetKeyDown(KeyCode.F))
			mLight.SetActive(!mLight.active);
	}
}
