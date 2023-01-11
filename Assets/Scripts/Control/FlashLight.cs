using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] private GameObject mLight;
    [SerializeField] private AudioSource AS;
    [SerializeField] private AudioClip blink, off;
    private bool started_off_routine = false;
    private void Start()
    {
        mLight.SetActive(false);
    }
    void Update()
    {
        if (!started_off_routine)
        {
            started_off_routine = true;
            StartCoroutine(randomClose());
        }
        if (Input.GetMouseButtonDown(1))
            mLight.SetActive(!mLight.activeSelf);
    }

    IEnumerator randomClose()
    {
        float close_time = Random.Range(30, 120);
        yield return new WaitForSeconds(close_time);
        if (!mLight.activeSelf)
        {
            started_off_routine = false;
            yield break;
        }
        mLight.SetActive(false);
        AS.PlayOneShot(blink);
        yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
        mLight.SetActive(true);
        AS.PlayOneShot(blink);
        yield return new WaitForSeconds(Random.Range(0.5f, 1.0f));
        mLight.SetActive(false);
        AS.PlayOneShot(blink);
        yield return new WaitForSeconds(Random.Range(0.25f, 0.75f));
        mLight.SetActive(true);
        AS.PlayOneShot(blink);
        yield return new WaitForSeconds(Random.Range(0, 0.5f));
        mLight.SetActive(false);
        AS.PlayOneShot(blink);
        yield return new WaitForSeconds(Random.Range(0.0f, 0.5f));
        mLight.SetActive(true);
        AS.PlayOneShot(blink);
        yield return new WaitForSeconds(Random.Range(0, 0.4f));
        mLight.SetActive(false);
        AS.PlayOneShot(blink);
        yield return new WaitForSeconds(Random.Range(0.0f, 0.4f));
        mLight.SetActive(true);
        AS.PlayOneShot(blink);
        yield return new WaitForSeconds(Random.Range(0, 0.3f));
        mLight.SetActive(false);
        AS.PlayOneShot(blink);
        yield return new WaitForSeconds(Random.Range(0.0f, 0.3f));
        mLight.SetActive(true);
        AS.PlayOneShot(blink);
        yield return new WaitForSeconds(Random.Range(0, 0.3f));
        mLight.SetActive(false);
        AS.PlayOneShot(blink);
        yield return new WaitForSeconds(Random.Range(0.0f, 0.3f));
        mLight.SetActive(true);
        AS.PlayOneShot(blink);
        yield return new WaitForSeconds(Random.Range(0.0f, 0.3f));
        mLight.SetActive(false);
        AS.PlayOneShot(blink);
        yield return new WaitForSeconds(Random.Range(0, 0.3f));
        mLight.SetActive(true);
        AS.PlayOneShot(blink);
        yield return new WaitForSeconds(Random.Range(0, 0.5f));
        mLight.SetActive(false);
        AS.PlayOneShot(off);
        started_off_routine = false;
    }
}
