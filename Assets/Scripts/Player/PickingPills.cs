using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingPills : MonoBehaviour
{
    public Canvas hints_1;
    public SceneLoader loader;
    public Canvas SanityEffect;
    public GameObject pill;

    private int sanity;
    private bool sanLock;
    private bool canPick;

    private void Start()
    {
        sanity = 2;
        sanLock = false;
        canPick = false;
    }

    private void Update()
    {
        if (sanity == 1)
        {
            SanityEffect.enabled = true;
        }
        else
        {
            if (sanity == 0)
            {
                sanity = 2;
                StartCoroutine(loader.ChangeScene());
                Instantiate(pill,
                    new Vector3(25.3419991f, -6.86999989f, -3.16000009f),
                    Quaternion.identity);
                Instantiate(pill,
                    new Vector3(31.6704674f, -2.19000006f, -7.05183172f),
                    Quaternion.identity);
            }
            SanityEffect.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            sanLock = true;
            if (canPick == true)
                sanity -= 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Medicine"))
        {
            //Debug.Log("can pick");
            hints_1.enabled = true;
            canPick = true;
            sanLock = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Medicine"))
        {
            if (sanLock == true)
            {
                Destroy(other.gameObject);
                sanLock = false;
                canPick = false;
                hints_1.enabled = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Medicine"))
        {
            canPick = false;
            //Debug.Log("can't pick");
            hints_1.enabled = false;
        }
    }
}
