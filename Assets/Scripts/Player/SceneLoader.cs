using LidarProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
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

    public enum gameState {Stage1, Stage2, Stage3, Stage3_1};
    public gameState curGameState;

    //private bool nowIsLight;

    private void Start()
    {
        //nowIsLight = true;
        curGameState = gameState.Stage1;
        showUI = ui.GetComponent<ShowUI>();
    }

    private void Update()
    {
        // Demo
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(ChangeScene());
        }
    }

    public IEnumerator ChangeScene()
    {
        showUI.EnabledUI(false);
        animator.SetTrigger("FadingStart");
        yield return new WaitForSeconds(1f);

        player.transform.Find("Particle Effect").gameObject.SetActive(true);
        darkWorld.SetActive(true);
        lightWorld.SetActive(false);
        flashlight.SetActive(false);
        scanner.SetActive(true);
        //nowIsLight = false;

        animator.SetTrigger("FadingStart");
        yield return new WaitForSeconds(1f);

        // In the Dark
        if (curGameState == gameState.Stage2)
        {
            yield return new WaitUntil(() => curGameState == gameState.Stage3);
        }
        else if (curGameState == gameState.Stage3) {
            yield return new WaitUntil(() => curGameState == gameState.Stage3_1);

        } else {
            Instantiate(timeLine);
            yield return new WaitForSeconds(30f);
        }

        // End Dark

        animator.SetTrigger("FadingStart");
        yield return new WaitForSeconds(1f);

        player.transform.Find("Particle Effect").gameObject.SetActive(false);
        lightWorld.SetActive(true);
        darkWorld.SetActive(false);
        flashlight.SetActive(true);
        scanner.SetActive(false);
        //nowIsLight = true;

        animator.SetTrigger("FadingStart");
        yield return new WaitForSeconds(1f);
        
        showUI.EnabledUI(true);
    }

    public void changeGameState(gameState newValue) {
        if (newValue <= curGameState) return;
        curGameState = newValue;
        switch(curGameState) {
            case gameState.Stage2:
            {
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
    public void InToTheDark()
    {
        StartCoroutine(ChangeScene());
    }
}
