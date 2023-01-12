using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class fallHole : MonoBehaviour {
	[SerializeField] private GameObject player;
	[SerializeField] private Animator zombieAnimator;
	[SerializeField] private GameObject retryCanvas;
	[SerializeField] private Light roomLight;
	[SerializeField] private GameObject zombie;
	[SerializeField] private SceneLoader loader;
	private bool isEnter;
	private void Start() {
		this.isEnter = false;
	}
	IEnumerator fallHoleTeleport() {
		this.zombieAnimator.SetBool("isScare", true);
		yield return new WaitForSeconds(0.2f);
		this.setPlayerState(false);
		for (int i = 0; i < this.player.transform.GetChild(0).childCount; i++)
			this.player.transform.GetChild(0).GetChild(i).gameObject.SetActive(false);
		this.player.transform.GetChild(0).rotation = new Quaternion(0, 0, 0, 0);
		this.player.transform.position = new Vector3(100f, 0.7f, 100.3f);
		this.player.transform.rotation = Quaternion.Euler(Vector3.zero);
		yield return new WaitForSeconds(0.1f);
		this.zombie.GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds(0.4f);
		this.isEnter = true;
		yield return new WaitForSeconds(1.1f);
		
		if (loader.darkWorldCoroutine != null)
			StartCoroutine(loader.forceEndDarkWorld());
		else {
			loader.fadingEffect();
			yield return new WaitForSeconds(0.5f);
            this.player.GetComponent<PlayerSave>().changePos(1);
			this.player.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
			loader.fadingEffect();
			yield return new WaitForSeconds(0.8f);
		}
		this.setPlayerState(true);
	}
	IEnumerator fallHoleTeleportWithoutScare() {
		if (loader.darkWorldCoroutine != null)
			StartCoroutine(loader.forceEndDarkWorld());
		else {
			loader.fadingEffect();
			yield return new WaitForSeconds(0.5f);
			this.setPlayerState(false);
			this.player.GetComponent<PlayerSave>().changePos(1);
			loader.fadingEffect();
			yield return new WaitForSeconds(0.8f);
			this.setPlayerState(true);
		}
	}
	void Update() {
		if (Input.GetKeyDown(KeyCode.M))
			StartCoroutine(this.fallHoleTeleport());
	}
	private void setPlayerState(bool state){
		this.player.GetComponent<LidarProject.Scanner>().enabled = state;
		this.player.GetComponent<FPController>().enabled = state;
		if(state)
			this.player.GetComponent<FPController>().revive();
		else
			this.player.GetComponent<FPController>().kill();
		
	}
	void FixedUpdate() {
		if (this.isEnter && roomLight.intensity < 0.6)
			roomLight.intensity += 0.02f;
	}
	void OnTriggerEnter(Collider other) {
		if (other.tag == "PlayerFake") {
			if (!this.isEnter)
				StartCoroutine(this.fallHoleTeleport());
			else
				StartCoroutine(this.fallHoleTeleportWithoutScare());
		}

	}
	public void reloadGame() {
		this.player.GetComponent<FPController>().revive();
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		Time.timeScale = 1;
		Cursor.visible = false;
	}
}
