using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leverDoorScript : MonoBehaviour
{
    [Tooltip("If it is false door can't be used")]
    public bool Locked = false;
    [Tooltip("It is true for remote control only")]
    public bool Remote = true;
    [Space]
    [Tooltip("Door can be opened")]
    public bool CanOpen = true;
    [Tooltip("Door can be closed")]
    public bool CanClose = false;
    [Space]
    [Tooltip("Door locked by red key (use key script to declarate any object as key)")]
    public bool RedLocked = false;
    public bool BlueLocked = false;
    [Tooltip("It is used for key script working")]
    AN_HeroInteractive HeroInteractive;
    [Space]
    public bool isOpened = false;
    [Range(0f, 4f)]
    [Tooltip("Speed for door opening, degrees per sec")]
    public float OpenSpeed = 3f;
	private int rotateTimes;
	[SerializeField] private GameObject door1;
	[SerializeField] private GameObject door2;
	[SerializeField] private GameObject dark_door1;
	[SerializeField] private GameObject dark_door2;

    // NearView()
    float distance;
    float angleView;
    Vector3 direction;

    // Hinge
    [HideInInspector]
    void Start()
    {
		this.rotateTimes = 0;
    }

    void Update()
    {        
    }

    public void Action() // void to open/close door
    {
        this.isOpened = true;
    }

    private void FixedUpdate() // door is physical object
    {
		if (this.isOpened && this.rotateTimes < 75) {
			door1.transform.Rotate(Vector3.down);
			door2.transform.Rotate(Vector3.up);
			dark_door1.transform.Rotate(Vector3.down);
			dark_door2.transform.Rotate(Vector3.up);
			this.rotateTimes++;
		}
    }
}
