using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTargetItem : MonoBehaviour {

	public Camera mCamera;

	private bool isTarget;
	public bool isMouseTargetAwake { set; get; }
	private enum targetItem { passwordDoor, putNewspaper };
	private targetItem nowTarget;
	private GameObject targetObject;
	private MeshRenderer targetObjectRenderer;

	// [SerializeField] private Material edgeMaterial;

	void Start() {
		this.isTarget = false;
		this.isMouseTargetAwake = true;
	}
	void Update() {
		if (!this.isMouseTargetAwake)
			return;
		RaycastHit hit;
		Ray ray = mCamera.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out hit)) {
			Transform objectHit = hit.transform;
			// Do something with the object that was hit by the raycast.
			switch (hit.collider.gameObject.name) {
				case "doorPassword":
					if (this.isTarget)
						break;
					this.isTarget = true;
					this.nowTarget = targetItem.passwordDoor;
					targetObject = GameObject.Find("doorPassword");
					targetObjectRenderer = targetObject.GetComponent<MeshRenderer>();
					targetObjectRenderer.enabled = true;
					break;
				case "PutNewspaper1":
					if (this.isTarget)
						break;
					this.isTarget = true;
					this.nowTarget = targetItem.putNewspaper;
					targetObject = GameObject.Find("PutNewspaper1");
					targetObjectRenderer = targetObject.GetComponent<MeshRenderer>();
					targetObjectRenderer.enabled = true;
					break;
				case "PutNewspaper2":
					if (this.isTarget)
						break;
					this.isTarget = true;
					this.nowTarget = targetItem.putNewspaper;
					targetObject = GameObject.Find("PutNewspaper2");
					targetObjectRenderer = targetObject.GetComponent<MeshRenderer>();
					targetObjectRenderer.enabled = true;
					break;
				case "PutNewspaper3":
					if (this.isTarget)
						break;
					this.isTarget = true;
					this.nowTarget = targetItem.putNewspaper;
					targetObject = GameObject.Find("PutNewspaper3");
					targetObjectRenderer = targetObject.GetComponent<MeshRenderer>();
					targetObjectRenderer.enabled = true;
					break;
				case "PutNewspaper4":
					if (this.isTarget)
						break;
					this.isTarget = true;
					this.nowTarget = targetItem.putNewspaper;
					targetObject = GameObject.Find("PutNewspaper4");
					targetObjectRenderer = targetObject.GetComponent<MeshRenderer>();
					targetObjectRenderer.enabled = true;
					break;
				default:
					this.isTarget = false;
					break;
			}
		} else
			this.isTarget = false;

		if (this.isTarget) {
			if (Input.GetMouseButtonUp(0))
				switch (this.nowTarget) {
					case targetItem.passwordDoor:
						this.targetObject.GetComponent<passwordDoor>().openCanvas();
						break;
					case targetItem.putNewspaper:
						this.targetObject.GetComponent<PutNewspaper>().Put();
						break;
					default:
						break;
				}
		} else {
			if (targetObject != null) {
				targetObjectRenderer.enabled = false;
				targetObject = null;
			}
		}
	}
}
