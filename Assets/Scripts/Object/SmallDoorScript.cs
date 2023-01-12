using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SmallDoorScript : MonoBehaviour
{
    public bool isOpened = true;
    private int rotateTimes = 80;
	[SerializeField] private GameObject door;
    [SerializeField] private AudioSource AS;
    [SerializeField] private GameObject hint;
    GameObject UI;
    bool canOpenDoor;
    // Start is called before the first frame update
    void Start()
    {
        canOpenDoor = true;
        UI = GameObject.Find("UI System");
    }

    // Update is called once per frame
    void Update()
    {
        canOpenDoor = !UI.GetComponent<ShowUI>().UIIsOpen();
        if (Input.GetKeyDown(KeyCode.E) && NearView())
        {
            if(canOpenDoor)
            {
                if (isOpened) closeDoor();
                else openDoor();
            }
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

    public void openDoor() {
        if (isOpened || rotateTimes < 80) return;
        Destroy(hint);
        AS.PlayOneShot(AS.clip);
        isOpened = true;
        rotateTimes = 80 - rotateTimes;
    }

    public void closeDoor() {
        if (!isOpened || rotateTimes < 80) return;
        AS.PlayOneShot(AS.clip);
        isOpened = false;
        rotateTimes = 80 - rotateTimes;
    }

    private void FixedUpdate() {
        if (rotateTimes < 80) {
            if (isOpened) {
                door.transform.Rotate(Vector3.up);
                this.rotateTimes++;
            } else {
                door.transform.Rotate(Vector3.down);
                this.rotateTimes++;
            }
        }
    }
}
