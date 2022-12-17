using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class fallHole : MonoBehaviour {
    [SerializeField] private GameObject player;
    [SerializeField] private Animator zombieAnimator;
    [SerializeField] private GameObject retryCanvas;
    IEnumerator fallHoleTeleport() {
        this.zombieAnimator.SetBool("isScare", true);
        this.player.GetComponent<FPController>().enabled = false;
        this.player.GetComponent<LidarProject.Scanner>().enabled = false;
        for (int i = 0; i < this.player.transform.GetChild(0).childCount; i++)
            this.player.transform.GetChild(0).GetChild(i).gameObject.SetActive(false);

        yield return new WaitForSeconds(0.35f);
        this.player.transform.GetChild(0).rotation = new Quaternion(0, 0, 0, 0);
        this.player.transform.position = new Vector3(100f, 0.7f, 100.3f);
        this.player.transform.rotation = Quaternion.Euler(Vector3.zero);
        yield return new WaitForSeconds(1.5f);
        this.retryCanvas.SetActive(true);
        Time.timeScale = 0;
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.M))
            StartCoroutine(this.fallHoleTeleport());
    }
    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
            StartCoroutine(this.fallHoleTeleport());
    }
    public void reloadGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
