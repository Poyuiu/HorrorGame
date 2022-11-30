using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator animator;
    public GameObject lightWorld;
    public GameObject darkWorld;

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

        if (nowIsLight)
        {
            darkWorld.SetActive(true);
            lightWorld.SetActive(false);
            nowIsLight = false;
        }
        else
        {
            lightWorld.SetActive(true);
            darkWorld.SetActive(false);
            nowIsLight = true;
        }

        animator.SetTrigger("FadingStart");
        yield return new WaitForSeconds(1f);
    }
}
