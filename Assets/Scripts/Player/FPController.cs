﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPController : MonoBehaviour {

	public float speed = 5f;
	public float mouseSensitivity =5f;
	public float jumpSpeed = 10f;

	private float rotationLeftRight;
	private float verticalRotation;
	private float forwardspeed;
	private float sideSpeed;
	private float verticalVelocity; 
	private Vector3 speedCombined;
	private CharacterController cc;
	private bool is_sprinting;
	private float defaultYpos;
	private float headBobTimer;
	private float walkBobSpeed = 10f;
	private float sprintBobSpeed = 19f;

    public AudioSource AS_BGM_Footstep;
    public AudioSource AS_Breath;
    public AudioClip footstepLeft, footstepRight;
	private bool footstepLeftHasPlayed, footstepRightHasPlayed;


    private Camera cam;

	// Use this for initialization
	void Start () {
		cam = GetComponentInChildren<Camera> ();
		cc = GetComponent<CharacterController> ();
		Cursor.visible = false;

		defaultYpos = cam.transform.localPosition.y;
	}

	// Update is called once per frame
	void Update () {

		rotationLeftRight = Input.GetAxis ("Mouse X") * mouseSensitivity;
		transform.Rotate (0, rotationLeftRight,0);

		verticalRotation -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
		verticalRotation = Mathf.Clamp (verticalRotation, -60f, 60f);
		cam.transform.localRotation = Quaternion.Euler (verticalRotation, 0,0);

		forwardspeed = Input.GetAxis ("Vertical") * speed;
		sideSpeed = Input.GetAxis ("Horizontal") * speed;

		if (Input.GetKey(KeyCode.LeftShift)) {
			forwardspeed *= 2f;
			is_sprinting = true;
			if (!AS_Breath.isPlaying) AS_Breath.Play();
		} else
		{
			is_sprinting = false;
			AS_Breath.Stop();
		}


		verticalVelocity += Physics.gravity.y * Time.deltaTime;

		if (cc.isGrounded) {
			if (Input.GetButtonDown("Jump"))
				verticalVelocity = jumpSpeed;
			else if (verticalVelocity < -1) {
				verticalVelocity = 0;
			}
		}

		speedCombined = new Vector3 (sideSpeed, verticalVelocity, forwardspeed);

		speedCombined = transform.rotation * speedCombined;

		cc.Move(speedCombined * Time.deltaTime);

		HandleHeadBob();

	}

	void HandleHeadBob()
	{
		if (!cc.isGrounded) return;
		
		if (Mathf.Abs(forwardspeed) > 0.1 || Mathf.Abs(sideSpeed) > 0.1) {
			float sineVal = Mathf.Sin(headBobTimer);

            headBobTimer += Time.deltaTime * (is_sprinting ? sprintBobSpeed : walkBobSpeed);
			cam.transform.localPosition = new Vector3(
				cam.transform.localPosition.x,
				defaultYpos + sineVal * 0.05f,
				cam.transform.localPosition.z
				);

			if (sineVal < -0.9 && !footstepLeftHasPlayed)
            {
                AS_BGM_Footstep.PlayOneShot(footstepLeft, 0.2f);
                footstepLeftHasPlayed = true;
			} else if (sineVal > 0.9 && !footstepRightHasPlayed)
			{
                AS_BGM_Footstep.PlayOneShot(footstepRight, 0.2f);
                footstepRightHasPlayed = true;
			} else
			{
				footstepLeftHasPlayed = footstepRightHasPlayed = false;
			}

		}
	}
}
