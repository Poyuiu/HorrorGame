using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class passwordDoor : MonoBehaviour {
	[SerializeField] private GameObject canvas;
	[SerializeField] private GameObject passwordTextObj;
	[SerializeField] private MouseTargetItem mouseTargetScript;
	[SerializeField] private GameObject door1;
	[SerializeField] private GameObject door2;
	[SerializeField] private GameObject FPSController;
	private string password;
	private TMP_Text passwordText;
	private const string passwordTextPrefix = "<mspace=1.47em>";
	private const string correctPassword = "1111";
	private bool isDoorOpen;
	private int rotateTimes;
	// Start is called before the first frame update
	void Start() {
		this.isDoorOpen = false;
		this.passwordText = this.passwordTextObj.GetComponent<TMP_Text>();
		this.password = "";
		this.passwordText.text = passwordTextPrefix;
		this.rotateTimes = 0;
	}
	// Update is called once per frame
	void Update() {
		this.passwordText.text = passwordTextPrefix + this.password;
	}
	public void openCanvas() {
		if (this.isDoorOpen)
			return;
		this.canvas.SetActive(true);
        this.FPSController.GetComponent<FPController>().enabled = false;
        this.FPSController.GetComponent<LidarProject.Scanner>().enabled = false;
		this.mouseTargetScript.isMouseTargetAwake = false;
	}
	public void closeCanvas() {
		this.password = "";
        this.FPSController.GetComponent<FPController>().enabled = true;
        this.FPSController.GetComponent<LidarProject.Scanner>().enabled = true;
		this.canvas.SetActive(false);
		this.mouseTargetScript.isMouseTargetAwake = true;
	}
	public void addZero() { if (this.password.Length < 4) this.password += "0"; }
	public void addOne() { if (this.password.Length < 4) this.password += "1"; }
	public void addTwo() { if (this.password.Length < 4) this.password += "2"; }
	public void addThree() { if (this.password.Length < 4) this.password += "3"; }
	public void addFour() { if (this.password.Length < 4) this.password += "4"; }
	public void addFive() { if (this.password.Length < 4) this.password += "5"; }
	public void addSix() { if (this.password.Length < 4) this.password += "6"; }
	public void addSeven() { if (this.password.Length < 4) this.password += "7"; }
	public void addEight() { if (this.password.Length < 4) this.password += "8"; }
	public void addNine() { if (this.password.Length < 4) this.password += "9"; }
	public void backspace() { if (this.password.Length > 0) this.password = this.password.Remove(this.password.Length - 1); }
	public void submit() {
		if (this.password != correctPassword)
			return;
		// open the door
		this.isDoorOpen = true;
		Destroy(this.gameObject.GetComponent<MeshRenderer>());
		Destroy(this.canvas, 0.5f);
		Destroy(this.gameObject, 2f);
		this.closeCanvas();
	}
	void FixedUpdate() {
		if (this.isDoorOpen && this.rotateTimes < 75) {
			door1.transform.Rotate(Vector3.down);
			door2.transform.Rotate(Vector3.up);
			this.rotateTimes++;
		}
	}
}
