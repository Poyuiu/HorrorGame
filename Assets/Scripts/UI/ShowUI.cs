using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowUI : UI
{
    [SerializeField] private GameObject canvas;
    //[SerializeField] private GameObject passwordTextObj;
    [SerializeField] private GameObject FPSController;
    [SerializeField] private GameObject closeBG;
    //private TMP_Text passwordText;
    bool active;
    // Start is called before the first frame update
    void Start()
    {
        _ = canvas.transform;
        active = true;
    }
    // Update is called once per frame
    void Update()
    {
        //this.passwordText.text = passwordTextPrefix + this.password;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isOpened) CloseCanvas();
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(active)
            {
                if (!isOpened)
                {
                    if (canOpen()) OpenCanvas();
                }
                else CloseCanvas();
            }
        }
    }
    public void OpenCanvas()
    {
        isOpened = true;
        Cursor.visible = true;
        this.canvas.SetActive(true);
        this.FPSController.GetComponent<FPController>().enabled = false;
        this.FPSController.GetComponent<LidarProject.Scanner>().enabled = false;
        this.FPSController.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
    }
    public void CloseCanvas()
    {
        isOpened = false;
        Cursor.visible = false;
        this.FPSController.GetComponent<FPController>().enabled = true;
        this.FPSController.GetComponent<LidarProject.Scanner>().enabled = true;
        this.FPSController.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        this.canvas.transform.GetChild(2).gameObject.
            GetComponent<DiaryEntry>().CloseManually();
        this.canvas.SetActive(false);
    }
    public void CloseBGShow()
    {
        this.closeBG.SetActive(true);
    }
    public void CloseBGNotShow()
    {
        this.closeBG.SetActive(false);
    }
    public void EnabledUI(bool a)
    {
        active = a;
    }
    public bool UIIsOpen()
    {
        return isOpened;
    }
}
