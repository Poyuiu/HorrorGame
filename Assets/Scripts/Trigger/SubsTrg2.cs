using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubsTrg2 : MonoBehaviour
{
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

            Vocals.instance.Say(forNull, 7);
        }
    }
}
