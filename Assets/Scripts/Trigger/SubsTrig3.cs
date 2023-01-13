using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubsTrig3 : MonoBehaviour
{
    public AudioClip sub10;

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

            Vocals.instance.Say(sub10, 10);
        }
    }
}
