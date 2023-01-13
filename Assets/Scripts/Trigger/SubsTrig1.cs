using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubsTrig1 : MonoBehaviour
{
    public AudioClip clip0;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
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
        Vocals.instance.Say(clip0, 0);
        yield return new WaitForSeconds(5.0f);
        Vocals.instance.Say(clip1, 1);
        yield return new WaitForSeconds(2f);
        Vocals.instance.Say(clip2, 2);
        yield return new WaitForSeconds(2f);
        Vocals.instance.Say(clip3, 3);
        yield return new WaitForSeconds(3f);
        //Vocals.instance.Say(forNull);
    }
}
