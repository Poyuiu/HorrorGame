using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollapse : MonoBehaviour {
	// Start is called before the first frame update
	private const string fractureName = "floor";
	public void enableGravity(Collider other, GameObject fragObg, Vector3 fragVec) {
		fragObg.GetComponent<Rigidbody>().useGravity = true;
		Destroy(fragObg.gameObject, 0.5f);
	}
	public void destoryFracture() {
		GameObject target = GameObject.Find(fractureName + "Fragments");
		if (target != null)
			Destroy(target, Random.Range(1f, 2f));
	}
}
