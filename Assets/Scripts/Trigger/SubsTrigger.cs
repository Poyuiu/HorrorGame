using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubsTrigger : MonoBehaviour
{
    public AudioClip clip;
    public AudioClip forNull;

    private bool oneTime;

    private void Start()
    {
        oneTime = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && oneTime)
        {
            //Debug.Log("Collid");
            oneTime = false;
            Vocals.instance.Say(clip);
            StartCoroutine(DisplayFlashlightHint());
        }
    }

    IEnumerator DisplayFlashlightHint()
    {
        yield return new WaitForSeconds(2.5f);
        Vocals.instance.Say(forNull);
    }
}
