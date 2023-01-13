using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FPController : MonoBehaviour
{

    public float speed = 5f;
    public float mouseSensitivity = 5f;
    public float jumpSpeed = 10f;

    private float rotationLeftRight;
    private float verticalRotation;
    private float forwardspeed;
    private float sideSpeed;
    private float verticalVelocity;
    private Vector3 speedCombined;
    private CharacterController cc;
    private bool is_sprinting, is_walking;
    private float defaultYpos;
    private float headBobTimer;
    private float walkBobSpeed = 10f;
    private float sprintBobSpeed = 19f;
    private bool dead = false;
    private bool lockMove = false;

    public AudioSource AS_Footstep, AS_Breath;
    public AudioClip footStep, footStep_sprint;


    private Camera cam;

    // Use this for initialization
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
        cc = GetComponent<CharacterController>();
        cc.minMoveDistance = 0;
        Cursor.visible = false;

        defaultYpos = cam.transform.localPosition.y;
    }

    private void OnDisable()
    {
        AS_Breath.Stop();
		AS_Footstep.Stop();
    }

    // Update is called once per frame
    void Update () {
        //Debug.Log(lockMove);
		if (dead)
		{
			AS_Footstep.Stop();
			AS_Breath.Stop();
			return;
		}

        rotationLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, rotationLeftRight, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -60f, 60f);
        cam.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        if (lockMove) return;

        forwardspeed = Input.GetAxis("Vertical") * speed;
        sideSpeed = Input.GetAxis("Horizontal") * speed;

        if (Input.GetKey(KeyCode.LeftShift) && forwardspeed > 0)
        {
            forwardspeed *= 2f;
            is_sprinting = true;
            if (!cc.isGrounded) AS_Breath.Stop();
            else if (!AS_Breath.isPlaying) AS_Breath.Play();
            AS_Footstep.clip = footStep_sprint;
        }
        else
        {
            is_sprinting = false;
            AS_Breath.Stop();
            AS_Footstep.clip = footStep;
        }

        if ((Mathf.Abs(forwardspeed) > 0 || Mathf.Abs(sideSpeed) > 0) && cc.isGrounded)
        {
            if (!AS_Footstep.isPlaying) AS_Footstep.Play();
        }
        else
        {
            AS_Footstep.Stop();
        }


        verticalVelocity += Physics.gravity.y * Time.deltaTime;

        if (cc.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
                verticalVelocity = jumpSpeed;
            else if (verticalVelocity < -1)
            {
                verticalVelocity = -0.1f * Time.deltaTime;
            }
        }

        speedCombined = new Vector3(sideSpeed, verticalVelocity, forwardspeed);

        speedCombined = transform.rotation * speedCombined;

        cc.Move(speedCombined * Time.deltaTime);

        HandleHeadBob();

    }

    void HandleHeadBob()
    {
        if (!cc.isGrounded) return;

        if (Mathf.Abs(forwardspeed) > 0.1 || Mathf.Abs(sideSpeed) > 0.1)
        {
            float sineVal = Mathf.Sin(headBobTimer);

            headBobTimer += Time.deltaTime * (is_sprinting ? sprintBobSpeed : walkBobSpeed);
            cam.transform.localPosition = new Vector3(
                cam.transform.localPosition.x,
                defaultYpos + sineVal * 0.05f,
                cam.transform.localPosition.z
                );

        }
    }

    public void Kill()
    {
        this.dead = true;
    }

    public void Revive()
    {
        this.dead = false;
    }

    public void LockMove()
    {
        this.AS_Footstep.Stop();
        this.lockMove = true;
    }

    public void UnlockMove()
    {
        this.lockMove = false;
    }
}
