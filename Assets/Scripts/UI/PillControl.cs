using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PillControl : MonoBehaviour
{
    public GameObject text;
    RectTransform iconRectTranform;
    public SceneLoader loader;
    public GameObject UI;
    ShowUI showUI;
    public GameObject bottle;
    public GameObject icon;

    int pillCount;
    // Start is called before the first frame update
    void Start()
    {
        pillCount = 0;
        iconRectTranform = icon.GetComponent<RectTransform>();
        showUI = UI.GetComponent<ShowUI>();
        if(pillCount == 0)
            bottle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        text.GetComponent<TextMeshProUGUI>().text = pillCount.ToString();
    }

    public void PickPill()
    {
        if(pillCount == 0)
            bottle.SetActive(true);
        pillCount++;
    }

    public void UsePill()
    {
        if(pillCount == 0)
            return;
        pillCount--;
        if(pillCount == 0)
            bottle.SetActive(false);
        loader.InToTheDark();
        showUI.CloseCanvas();
    }

    
    public void PointerEnter()
    {
        if(pillCount == 0)
            return;
        iconRectTranform.localScale = new Vector3(1.1f, 1.1f, 1f);
    }

    public void PointerLeave()
    {
        if(pillCount == 0)
            return;
        iconRectTranform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void PointerClick()
    {
        UsePill();
    }
}
