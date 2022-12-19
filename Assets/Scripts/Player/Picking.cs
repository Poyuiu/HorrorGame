using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picking : MonoBehaviour
{
    // public Canvas hints_1;
    public SceneLoader loader;
    public Canvas SanityEffect;

    private int sanity;
    private bool sanLock;
    private bool canPickPill;
    private bool canPickNewspaper;
    private bool goPickNewspaper;
    public bool leverHint = false;
    private void Start()
    {
        sanity = 2;
        sanLock = false;
        canPickPill = false;
        canPickNewspaper = false;
        goPickNewspaper = false;
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
            }
            SanityEffect.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            sanLock = true;
            if (canPickPill == true)
                sanity -= 1;
            if (canPickNewspaper)
            {
                goPickNewspaper = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Medicine"))
        {
            //Debug.Log("can pick");
            // hints_1.enabled = true;
            //Debug.Log(other.gameObject.transform.GetChild(2).name);
            other.gameObject.transform.GetChild(2).gameObject.SetActive(true);
            canPickPill = true;
            sanLock = false;
        }
        else if (other.gameObject.CompareTag("Newspaper"))
        {
            other.gameObject.transform.GetChild(2).gameObject.SetActive(true);
            canPickNewspaper = true;
        }
        else if (other.gameObject.CompareTag("Lever")) {
            if (leverHint) {
                other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
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
                canPickPill = false;
                // hints_1.enabled = false;
                other.gameObject.transform.GetChild(2).gameObject.SetActive(false);
            }
        } if (other.gameObject.CompareTag("Newspaper"))
        {
            if(goPickNewspaper)
            {
                other.gameObject.GetComponent<NewspaperAction>().Pick();
                goPickNewspaper = false;
                other.gameObject.SetActive(false);
                canPickNewspaper = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Medicine"))
        {
            canPickPill = false;
            //Debug.Log("can't pick");
            // hints_1.enabled = false;
            other.gameObject.transform.GetChild(2).gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Newspaper"))
        {
            other.gameObject.transform.GetChild(2).gameObject.SetActive(false);
            canPickNewspaper = false;
        }
        else if (other.gameObject.CompareTag("Lever")) {
            other.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
