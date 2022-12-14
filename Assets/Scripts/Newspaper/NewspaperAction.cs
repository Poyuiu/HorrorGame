using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewspaperAction : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject putNewspaper;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pick()
    {
        putNewspaper.GetComponent<PutNewspaper>().Pick();
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
    }
}
