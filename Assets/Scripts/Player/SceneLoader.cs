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

    private bool nowIsLight;

    private void Start()
    {
        nowIsLight = true;
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
        animator.SetTrigger("FadingStart");
        yield return new WaitForSeconds(1f);

        player.transform.Find("Particle Effect").gameObject.SetActive(true);
        darkWorld.SetActive(true);
        lightWorld.SetActive(false);
        flashlight.SetActive(false);
        scanner.SetActive(true);
        nowIsLight = false;

        animator.SetTrigger("FadingStart");
        yield return new WaitForSeconds(1f);

        // In the Dark

        Instantiate(timeLine);
        yield return new WaitForSeconds(30f);

        // End Dark

        animator.SetTrigger("FadingStart");
        yield return new WaitForSeconds(1f);

        player.transform.Find("Particle Effect").gameObject.SetActive(false);
        lightWorld.SetActive(true);
        darkWorld.SetActive(false);
        flashlight.SetActive(true);
        scanner.SetActive(false);
        nowIsLight = true;

        animator.SetTrigger("FadingStart");
        yield return new WaitForSeconds(1f);

        Instantiate(pills,
                    new Vector3(25.3419991f, -6.86999989f, -3.16000009f),
                    Quaternion.identity);
        Instantiate(pills,
            new Vector3(31.6704674f, -2.19000006f, -7.05183172f),
            Quaternion.identity);
    }
}
