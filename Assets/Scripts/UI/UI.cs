using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    protected bool isOpened = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected bool canOpen()
    {
        UI[] allUIs = FindObjectsOfType<UI>();
        bool can = true;
        foreach (UI ui in allUIs)
        {
            if (ui.IsOpen()) can = false;
        }
        return can;
    }

    public bool IsOpen()
    {
        return isOpened;
    }
}
