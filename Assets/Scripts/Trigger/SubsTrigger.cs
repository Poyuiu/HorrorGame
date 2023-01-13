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

            StartCoroutine(DisplayStartUpSubs());
        }
    }

    IEnumerator DisplayStartUpSubs()
    {
        Vocals.instance.Say(clip, 0);
        yield return new WaitForSeconds(2.5f);
        Vocals.instance.Say(forNull, 0);
    }
}
