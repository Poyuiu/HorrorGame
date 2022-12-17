using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class passwordDoor : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    //[SerializeField] private GameObject passwordTextObj;
    [SerializeField] private MouseTargetItem mouseTargetScript;
    [SerializeField] private GameObject door1;
    [SerializeField] private GameObject door2;
    [SerializeField] private GameObject FPSController;
    [SerializeField] private List<GameObject> numberWithGrayFilter;
    private string password;
    //private TMP_Text passwordText;
    private const string passwordTextPrefix = "<mspace=1.47em>";
    private const string correctPassword = "9487";
    private bool isDoorOpen;
    private int rotateTimes;

    // Start is called before the first frame update
    void Start()
    {
        this.isDoorOpen = false;
        //this.passwordText = this.passwordTextObj.GetComponent<TMP_Text>();
        this.password = "";
        //this.passwordText.text = passwordTextPrefix;
        this.rotateTimes = 0;

        Transform t = canvas.transform;
        foreach (Transform tr in t)
        {
            if (tr.CompareTag("Keypad Gray"))
            {
                Debug.Log(tr.gameObject.name);
                numberWithGrayFilter.Add(tr.gameObject);
            }
        }
        Debug.Log(numberWithGrayFilter.Count);
    }
    // Update is called once per frame
    void Update()
    {
        //this.passwordText.text = passwordTextPrefix + this.password;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            closeCanvas();
        }
    }
    public void openCanvas()
    {
        if (this.isDoorOpen)
            return;
        Cursor.visible = true;
        this.canvas.SetActive(true);
        this.FPSController.GetComponent<FPController>().enabled = false;
        this.FPSController.GetComponent<LidarProject.Scanner>().enabled = false;
        this.FPSController.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
        this.mouseTargetScript.isMouseTargetAwake = false;
    }
    public void closeCanvas()
    {
        this.password = "";
        Cursor.visible = false;
        this.FPSController.GetComponent<FPController>().enabled = true;
        this.FPSController.GetComponent<LidarProject.Scanner>().enabled = true;
        this.FPSController.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        this.canvas.SetActive(false);
        this.mouseTargetScript.isMouseTargetAwake = true;
    }
    public void addZero()
    {
        if (this.password.Length < 4)
        {
            this.password += "0";
            numberWithGrayFilter[0].SetActive(true);
        }
    }
    public void addOne()
    {
        if (this.password.Length < 4)
        {
            this.password += "1";
            //Debug.Log(numberWithGrayFilter[0].name);
            numberWithGrayFilter[1].SetActive(true);
        }
    }
    public void addTwo()
    {
        if (this.password.Length < 4)
        {
            this.password += "2";
            numberWithGrayFilter[2].SetActive(true);
        }
    }
    public void addThree()
    {
        if (this.password.Length < 4)
        {
            this.password += "3";
            numberWithGrayFilter[3].SetActive(true);
        }
    }
    public void addFour()
    {
        if (this.password.Length < 4)
        {
            this.password += "4";
            numberWithGrayFilter[4].SetActive(true);
        }
    }
    public void addFive()
    {
        if (this.password.Length < 4)
        {
            this.password += "5";
            numberWithGrayFilter[5].SetActive(true);
        }
    }
    public void addSix()
    {
        if (this.password.Length < 4)
        {
            this.password += "6";
            numberWithGrayFilter[6].SetActive(true);
        }
    }
    public void addSeven()
    {
        if (this.password.Length < 4)
        {
            this.password += "7";
            numberWithGrayFilter[7].SetActive(true);
        }
    }
    public void addEight()
    {
        if (this.password.Length < 4)
        {
            this.password += "8";
            numberWithGrayFilter[8].SetActive(true);
        }
    }
    public void addNine()
    {
        if (this.password.Length < 4)
        {
            this.password += "9";
            numberWithGrayFilter[9].SetActive(true);
        }
    }
    public void backspace() { if (this.password.Length > 0) this.password = this.password.Remove(this.password.Length - 1); }
    public void submit()
    {
        if (this.password != correctPassword)
        {
            for (int i = 0; i < 10; i++)
                numberWithGrayFilter[i].SetActive(false);
            this.password = "";
            return;
        }
        // open the door
        this.isDoorOpen = true;
        Destroy(this.gameObject.GetComponent<MeshRenderer>());
        Destroy(this.canvas, 0.5f);
        Destroy(this.gameObject, 2f);
        this.closeCanvas();
    }
    void FixedUpdate()
    {
        if (this.isDoorOpen && this.rotateTimes < 75)
        {
            door1.transform.Rotate(Vector3.down);
            door2.transform.Rotate(Vector3.up);
            this.rotateTimes++;
        }
    }
}
