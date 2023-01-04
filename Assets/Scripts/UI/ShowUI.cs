using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowUI : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    //[SerializeField] private GameObject passwordTextObj;
    [SerializeField] private MouseTargetItem mouseTargetScript;
    [SerializeField] private GameObject FPSController;
    //private TMP_Text passwordText;

    // Start is called before the first frame update
    void Start()
    {
        Transform t = canvas.transform;
    }
    // Update is called once per frame
    void Update()
    {
        //this.passwordText.text = passwordTextPrefix + this.password;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            closeCanvas();
        }
        else if(Input.GetKeyDown(KeyCode.Tab))
        {
            openCanvas();
        }
    }
    public void openCanvas()
    {
        Cursor.visible = true;
        this.canvas.SetActive(true);
        this.FPSController.GetComponent<FPController>().enabled = false;
        this.FPSController.GetComponent<LidarProject.Scanner>().enabled = false;
        this.FPSController.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
        this.mouseTargetScript.isMouseTargetAwake = false;
    }
    public void closeCanvas()
    {
        Cursor.visible = false;
        this.FPSController.GetComponent<FPController>().enabled = true;
        this.FPSController.GetComponent<LidarProject.Scanner>().enabled = true;
        this.FPSController.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        this.canvas.SetActive(false);
        StartCoroutine(ForMouseClose());
    }
    public IEnumerator ForMouseClose()
    {
        yield return new WaitForSeconds(0.2f);
        this.mouseTargetScript.isMouseTargetAwake = true;
    }
}
