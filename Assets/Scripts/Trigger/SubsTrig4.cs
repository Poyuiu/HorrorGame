using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubsTrig4 : MonoBehaviour
{
    public AudioClip sub16;

    private bool oneTime;
    [SerializeField] DoorScript door;

    private void Start()
    {
        oneTime = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && oneTime && !door.isOpened)
        {
            //Debug.Log("Collid");
            oneTime = false;

            Vocals.instance.Say(sub16, 16);
        }
    }
}
