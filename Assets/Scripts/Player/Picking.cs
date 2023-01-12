using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picking : MonoBehaviour
{
    // public Canvas hints_1;
    public Canvas SanityEffect;
    public GameObject PillControler;


    private PillControl pillControl;
    private bool sanLock;
    private bool canPickPill;
    private bool canPickDiary;
    private bool goPickDiary;
    public bool leverHint = false;
    private void Start()
    {
        pillControl = PillControler.GetComponent<PillControl>();
        sanLock = false;
        canPickPill = false;
        canPickDiary = false;
        goPickDiary = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            sanLock = true;
            if (canPickPill == true)
                pillControl.PickPill();
            if (canPickDiary)
            {
                goPickDiary = true;
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
        }
        else if (other.gameObject.CompareTag("Lever")) {
            if (leverHint) {
                other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
        else if (other.gameObject.CompareTag("Door"))
        {
            other.gameObject.transform.Find("Hints")?.gameObject.SetActive(true);
        }
        else if (other.gameObject.CompareTag("Diary"))
        {
            other.gameObject.transform.GetChild(2).gameObject.SetActive(true);
            canPickDiary = true;
        } 
        else if (other.gameObject.CompareTag("BlackBoard"))
        {
            other.gameObject.transform.Find("Hints").gameObject.SetActive(true);
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
        } if (other.gameObject.CompareTag("Diary"))
        {
            if(goPickDiary)
            {
                other.gameObject.GetComponent<DiaryPageControl>().Pick();
                goPickDiary = false;
                other.gameObject.SetActive(false);
                canPickDiary = false;
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
        }
        else if (other.gameObject.CompareTag("Lever")) {
            other.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Door"))
        {
            other.gameObject.transform.Find("Hints")?.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Diary"))
        {
            other.gameObject.transform.GetChild(2).gameObject.SetActive(false);
            canPickDiary = false;
        }
        else if (other.gameObject.CompareTag("BlackBoard"))
        {
            other.gameObject.transform.Find("Hints").gameObject.SetActive(false);
        }
    }
}
