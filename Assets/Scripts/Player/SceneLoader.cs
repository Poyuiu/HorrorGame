using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator animator;

    private void Update()
    {
        // Demo
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(ChangeScene());
        }
    }

    IEnumerator ChangeScene()
    {
        animator.SetTrigger("FadingStart");
        yield return new WaitForSeconds(1f);
        //SceneManager.LoadScene("Test", LoadSceneMode.Additive);

        // switch
        Scene scene = SceneManager.GetActiveScene();
        int kase = 1;
        int switchIndex = kase - scene.buildIndex;
        SceneManager.LoadScene(switchIndex);
    }
}
