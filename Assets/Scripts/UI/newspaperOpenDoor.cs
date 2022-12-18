using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class newspaperOpenDoor : MonoBehaviour
{
    [SerializeField] private GameObject door1;
    [SerializeField] private GameObject door2;
    [SerializeField] private GameObject dark_door1;
    [SerializeField] private GameObject dark_door2;
    private bool isDoorOpen;
    private int rotateTimes;

    // Start is called before the first frame update
    void Start()
    {
        this.isDoorOpen = false;
        //this.passwordText = this.passwordTextObj.GetComponent<TMP_Text>();
        //this.passwordText.text = passwordTextPrefix;
        this.rotateTimes = 0;
    }
    // Update is called once per frame
    void Update()
    {
    }
    public void OpenDoor()
    {
        this.isDoorOpen = true;
    }
    void FixedUpdate()
    {
        if (this.isDoorOpen && this.rotateTimes < 75)
        {
            door1.transform.Rotate(Vector3.down);
            door2.transform.Rotate(Vector3.up);
            //dark_door1.transform.Rotate(Vector3.down);
            //dark_door2.transform.Rotate(Vector3.up);
            this.rotateTimes++;
        }
    }
}
