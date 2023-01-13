using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class passwordDoor : UI
{
    [SerializeField] private GameObject canvas;
    //[SerializeField] private GameObject passwordTextObj;
    [SerializeField] private GameObject door1;
    [SerializeField] private GameObject door2;
    [SerializeField] private GameObject dark_door1;
    [SerializeField] private GameObject dark_door2;
    [SerializeField] public DoorScript door;
    [SerializeField] private GameObject hint;
    [SerializeField] private GameObject FPSController;
    [SerializeField] private List<GameObject> numberWithGrayFilter;
    private string password;
    private const string correctPassword = "9487";
    private bool isDoorOpen;

    private bool fc;
    public AudioClip sub11;
    public AudioClip sub12;
    public AudioClip sub13;
    public AudioClip sub14;


    // Start is called before the first frame update
    void Start()
    {
        if (FPSController.GetComponent<PlayerSave>().nowSP >= 1)
            Destroy(this.gameObject);
        this.isDoorOpen = false;
        //this.passwordText = this.passwordTextObj.GetComponent<TMP_Text>();
        this.password = "";
        //this.passwordText.text = passwordTextPrefix;

        Transform t = canvas.transform;
        foreach (Transform tr in t)
        {
            if (tr.CompareTag("Keypad Gray"))
            {
                numberWithGrayFilter.Add(tr.gameObject);
            }
        }

        fc = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && NearView())
        {
            if (!isOpened)
            {
                if (canOpen()) OpenCanvas();
            }
            else CloseCanvas();
        }
        //this.passwordText.text = passwordTextPrefix + this.password;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isOpened) CloseCanvas();
        }
    }

    bool NearView()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector3 direction = transform.position - Camera.main.transform.position;
        float angleView = Vector3.Angle(Camera.main.transform.forward, direction);
        if (angleView < 60f && distance < 3f) return true;
        else return false;
    }
    public void OpenCanvas()
    {
        Destroy(hint);
        isOpened = true;
        if (this.isDoorOpen)
            return;
        Cursor.visible = true;
        this.canvas.SetActive(true);
        this.FPSController.GetComponent<FPController>().enabled = false;
        this.FPSController.GetComponent<LidarProject.Scanner>().enabled = false;
        this.FPSController.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
    }
    public void CloseCanvas()
    {
        isOpened = false;
        if (this.password != correctPassword)
        {
            for (int i = 0; i < 10; i++)
                numberWithGrayFilter[i].SetActive(false);
            this.password = "";
        }
        this.password = "";
        Cursor.visible = false;
        this.FPSController.GetComponent<FPController>().enabled = true;
        this.FPSController.GetComponent<LidarProject.Scanner>().enabled = true;
        this.FPSController.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        this.canvas.SetActive(false);
        StartCoroutine(ForMouseClose());

        if (fc)
        {
            fc = false;
            StartCoroutine(FirstCloseDoor());
        }
    }
    public IEnumerator ForMouseClose()
    {
        yield return new WaitForSeconds(0.2f);
    }
    public IEnumerator FirstCloseDoor()
    {
        Vocals.instance.Say(sub11, 11);
        yield return new WaitForSeconds(2f);
        Vocals.instance.Say(sub12, 12);
        yield return new WaitForSeconds(1.5f);
        Vocals.instance.Say(sub13, 13);
        yield return new WaitForSeconds(2f);
        Vocals.instance.Say(sub14, 14);
        yield return new WaitForSeconds(2.5f);
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
        //this.isDoorOpen = true;
        door.openDoor();
        Destroy(this.gameObject.GetComponent<MeshRenderer>());
        Destroy(this.canvas, 0.5f);
        Destroy(this.gameObject, 2f);
        //this.firstClose = false;
        this.CloseCanvas();
    }
    void FixedUpdate()
    {
        //if (this.isDoorOpen && this.rotateTimes < 75)
        //{
        //    door1.transform.Rotate(Vector3.down);
        //    door2.transform.Rotate(Vector3.up);
        //    dark_door1.transform.Rotate(Vector3.down);
        //    dark_door2.transform.Rotate(Vector3.up);
        //    this.rotateTimes++;
        //}
    }
}
