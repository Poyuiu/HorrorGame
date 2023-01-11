using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PillControl : MonoBehaviour
{
    public GameObject text;
    RectTransform rectTranform;
    public SceneLoader loader;
    public GameObject UI;
    ShowUI showUI;

    int pillCount;
    // Start is called before the first frame update
    void Start()
    {
        pillCount = 1;
        rectTranform = gameObject.GetComponent<RectTransform>();
        showUI = UI.GetComponent<ShowUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.GetComponent<TextMeshProUGUI>().text = pillCount.ToString();
    }

    public void PickPill()
    {
        pillCount++;
    }

    public void UsePill()
    {
        if(pillCount == 0)
            return;
        pillCount--;
        loader.InToTheDark();
        showUI.CloseCanvas();
    }

    
    public void PointerEnter()
    {
        if(pillCount == 0)
            return;
        rectTranform.localScale = new Vector3(1.1f, 1.1f, 1f);
    }

    public void PointerLeave()
    {
        if(pillCount == 0)
            return;
        rectTranform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void PointerClick()
    {
        UsePill();
    }
}
