using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllNewspaperPicked : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject putNewspaper1;
    public GameObject putNewspaper2;
    public GameObject putNewspaper3;
    public GameObject putNewspaper4;
    public bool allPicked;
    void Start()
    {
        allPicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!allPicked &&
        putNewspaper1.GetComponent<PutNewspaper>().state == PutNewspaper.State.OnBulletin &&
        putNewspaper2.GetComponent<PutNewspaper>().state == PutNewspaper.State.OnBulletin &&
        putNewspaper3.GetComponent<PutNewspaper>().state == PutNewspaper.State.OnBulletin &&
        putNewspaper4.GetComponent<PutNewspaper>().state == PutNewspaper.State.OnBulletin)
        {
            allPicked = true;
        }
        Debug.Log(allPicked);
    }
}
