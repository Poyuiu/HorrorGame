using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBoard : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject FPSController;
    [SerializeField] private DoorScript door;


    private GameObject[] newspapers;
    private bool isOpen = false;
    private bool[] hasNewspaper;
    private GameObject hint;

    // Start is called before the first frame update
    void Awake()
    {
        newspapers = new GameObject[5];
        hasNewspaper= new bool[5];
        hint = transform.Find("Hints").gameObject;
        for (int i = 1; i <= 4; i++)
        {
            newspapers[i] = transform.Find("Newspaper" + i).gameObject;
            hasNewspaper[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && NearView())
        {
            Destroy(hint);
            if (!isOpen) OpenCanvas();
            else CloseCanvas();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isOpen) CloseCanvas();
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
        isOpen = true;
        Cursor.visible = true;
        this.canvas.SetActive(true);
        this.FPSController.GetComponent<FPController>().enabled = false;
        this.FPSController.GetComponent<LidarProject.Scanner>().enabled = false;
        this.FPSController.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
    }
    public void CloseCanvas()
    {
        isOpen = false;
        Cursor.visible = false;
        this.FPSController.GetComponent<FPController>().enabled = true;
        this.FPSController.GetComponent<LidarProject.Scanner>().enabled = true;
        this.FPSController.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        this.canvas.SetActive(false);
    }

    public void showNewspaper(uint newspaperNum)
    {
        newspapers[newspaperNum].SetActive(true);
        hasNewspaper[newspaperNum] = true;
        bool allPlaced = true;
        for (int i = 1; i <= 4; i++)
            if (!hasNewspaper[i]) allPlaced = false;
        if (allPlaced)
            door.openDoor();
    }
}
