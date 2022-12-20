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
    private bool isEnter = false;
    IEnumerator fallHoleTeleport() {
        this.zombieAnimator.SetBool("isScare", true);
        this.player.GetComponent<LidarProject.Scanner>().enabled = false;
        yield return new WaitForSeconds(0.4f);
        this.player.GetComponent<FPController>().enabled = false;
        for (int i = 0; i < this.player.transform.GetChild(0).childCount; i++)
            this.player.transform.GetChild(0).GetChild(i).gameObject.SetActive(false);
        this.player.transform.GetChild(0).rotation = new Quaternion(0, 0, 0, 0);
        this.player.transform.position = new Vector3(100f, 0.7f, 100.3f);
        this.player.transform.rotation = Quaternion.Euler(Vector3.zero);
        yield return new WaitForSeconds(0.1f);
        this.zombie.GetComponent<AudioSource>().Play();
        Cursor.visible = true;
        yield return new WaitForSeconds(0.4f);
        this.isEnter = true;
        yield return new WaitForSeconds(0.9f);
        this.retryCanvas.SetActive(true);
        Time.timeScale = 0;
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.M))
            StartCoroutine(this.fallHoleTeleport());
    }
    void FixedUpdate() {
        if (this.isEnter && roomLight.intensity < 0.6)
            roomLight.intensity += 0.02f;
    }
    void OnTriggerEnter(Collider other) {
        if (other.tag == "PlayerFake")
            StartCoroutine(this.fallHoleTeleport());

    }
    public void reloadGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
