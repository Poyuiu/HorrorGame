using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class passwordDoor : MonoBehaviour {
	[SerializeField] private GameObject canvas;
	[SerializeField] private GameObject passwordTextObj;
	[SerializeField] private MouseTargetItem mouseTargetScript;
	private string password;
	private TMP_Text passwordText;
	private const string passwordTextPrefix = "<mspace=1.47em>";
	private const string correctPassword = "1234";
	// Start is called before the first frame update
	void Start() {
		this.passwordText = this.passwordTextObj.GetComponent<TMP_Text>();
		this.password = "";
		this.passwordText.text = passwordTextPrefix;
	}
	// Update is called once per frame
	void Update() {
		this.passwordText.text = passwordTextPrefix + this.password;
	}
	public void openCanvas() {
		this.canvas.SetActive(true);
		this.mouseTargetScript.isMouseTargetAwake = false;
	}
	public void closeCanvas() {
		this.password = "";
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
		this.closeCanvas();
	}
}
