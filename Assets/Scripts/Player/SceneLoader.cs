using LidarProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    public Animator animator;
    public GameObject lightWorld;
    public GameObject darkWorld;
    public GameObject player;
    public GameObject timeLine;

    public GameObject flashlight;
    public GameObject scanner;
    public GameObject pills;
    public DoorScript stage3Doors;
    public Material stage3FloorMaterialBIG;
    public MeshRenderer stage3FloorMeshRenderer;
    public WalkingZombie walkingZombie;

    public GameObject ui;
    ShowUI showUI;
    public enum gameState { Stage1, Stage2, Stage3, Stage3_1 };
    public gameState curGameState;

    public Coroutine darkWorldCoroutine;
    private GameObject timelineInstantiation;
    private float darkTimeCount;

    //private bool nowIsLight;

    private bool firstIntoDark;
    public AudioClip forNull;
    private void Start()
    {
        //nowIsLight = true;
        curGameState = gameState.Stage1;
        showUI = ui.GetComponent<ShowUI>();
        firstIntoDark = true;
    }

    private void Update() {
        // Demo
        if (Input.GetKeyDown(KeyCode.P)) {
            if (this.darkWorldCoroutine == null)
                this.darkWorldCoroutine = StartCoroutine(ChangeScene());
            else
                StartCoroutine(forceEndDarkWorld());
        }
        // avoid bug in fading effect
        if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.Equals("CrossFadeEnd"))
            darkTimeCount = 0;
        else
            darkTimeCount += Time.deltaTime;
        if (darkTimeCount > 2.0f) {
            animator.SetTrigger("FadingStart");
            this.player.GetComponent<PlayerSave>().changePos(1);
            darkTimeCount = 0;
        }
    }

    public IEnumerator ChangeScene() {
        showUI.EnabledUI(false);
        animator.SetTrigger("FadingStart");
        yield return new WaitForSeconds(0.5f);

        this.setWorldObjectState(false);
        //nowIsLight = false;

        animator.SetTrigger("FadingStart");
        yield return new WaitForSeconds(0.5f);

        if (firstIntoDark)
        {
            firstIntoDark = false;
            Vocals.instance.Say(forNull, 15);
        }
        // In the Dark
        if (curGameState == gameState.Stage2) {
            yield return new WaitUntil(() => curGameState == gameState.Stage3);
        } else if (curGameState == gameState.Stage3) {
            yield return new WaitUntil(() => curGameState == gameState.Stage3_1);

        } else {
            this.timelineInstantiation = Instantiate(timeLine);
            yield return new WaitForSeconds(30f);
        }

        // End Dark

        showUI.EnabledUI(true);
        animator.SetTrigger("FadingStart");
        yield return new WaitForSeconds(0.5f);

        this.setWorldObjectState(true);
        //nowIsLight = true;

        animator.SetTrigger("FadingStart");
        yield return new WaitForSeconds(0.5f);
        this.timelineInstantiation.SetActive(false);
        Destroy(this.timelineInstantiation);
    }

    public IEnumerator forceEndDarkWorld() {
        StopCoroutine(this.darkWorldCoroutine);
        this.darkWorldCoroutine = null;
        animator.SetTrigger("FadingStart");
        yield return new WaitForSeconds(0.5f);

        this.setWorldObjectState(true);
        GameObject.Find("FloorCollapseEvent").GetComponent<FloorCollapse>().respawnFloor();
        this.player.GetComponent<PlayerSave>().changePos(1);
        animator.SetTrigger("FadingStart");
        this.timelineInstantiation.SetActive(false);
        Destroy(this.timelineInstantiation);
        yield return new WaitForSeconds(0.5f);
    }
    public void fadingEffect() => animator.SetTrigger("FadingStart");
    // true for normal world / false for dark world
    private void setWorldObjectState(bool state) {
        player.transform.Find("Particle Effect").gameObject.SetActive(!state);
        lightWorld.SetActive(state);
        darkWorld.SetActive(!state);
        flashlight.SetActive(state);
        scanner.SetActive(!state);
    }

    public void changeGameState(gameState newValue) {
        if (newValue <= curGameState) return;
        curGameState = newValue;
        switch (curGameState) {
            case gameState.Stage2: {
                    walkingZombie.is_walking = true;
                    break;
                }
            case gameState.Stage3: {
                    stage3Doors.closeDoor();
                    break;
                }
            case gameState.Stage3_1: {
                    player.GetComponent<Picking>().leverHint = true;
                    stage3FloorMeshRenderer.material = stage3FloorMaterialBIG;
                    break;
                }
        }
    }
    public void InToTheDark() {
        StartCoroutine(ChangeScene());
    }
}
