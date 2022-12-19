using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutNewsPaper : MonoBehaviour {
	public GameObject newspaper;
	public enum State { OnFloor, WithPlayer, OnBulletin };
	public State state;
	//0 is not picked, 1 is picked
	// Start is called before the first frame update
	void Start() {
		state = State.OnFloor;
	}
	// Update is called once per frame
	void Update() {
	}
	void FixedUpdate() {
	}
	public void Pick() {
		if (state == State.OnFloor) state = State.WithPlayer;
	}
	public void Put() {
		if (state == State.WithPlayer) {
			state = State.OnBulletin;
			newspaper.SetActive(true);
			newspaper.GetComponent<BoxCollider>().enabled = false;
			newspaper.transform.position = transform.position;
			newspaper.transform.rotation = transform.rotation;
			newspaper.transform.localScale = new Vector3(1.2f,0.02f,1.2f);
			gameObject.SetActive(false); 
		}
	}
}
