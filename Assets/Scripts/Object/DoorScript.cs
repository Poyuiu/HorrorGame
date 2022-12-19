using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool isOpened = true;
    private int rotateTimes = 80;
	[SerializeField] private GameObject door1;
	[SerializeField] private GameObject door2;
	[SerializeField] private GameObject dark_door1;
	[SerializeField] private GameObject dark_door2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openDoor() {
        if (isOpened) return;
        isOpened = true;
        rotateTimes = 80 - rotateTimes;
    }

    public void closeDoor() {
        if (!isOpened || rotateTimes < 80) return;
        isOpened = false;
        rotateTimes = 80 - rotateTimes;
    }

    private void FixedUpdate() {
        if (rotateTimes < 80) {
            if (isOpened) {
                door1.transform.Rotate(Vector3.up);
                door2.transform.Rotate(Vector3.down);
                dark_door1.transform.Rotate(Vector3.up);
                dark_door2.transform.Rotate(Vector3.down);
                this.rotateTimes++;
            } else {
                door1.transform.Rotate(Vector3.down);
                door2.transform.Rotate(Vector3.up);
                dark_door1.transform.Rotate(Vector3.down);
                dark_door2.transform.Rotate(Vector3.up);
                this.rotateTimes++;
            }
        }
    }
}
