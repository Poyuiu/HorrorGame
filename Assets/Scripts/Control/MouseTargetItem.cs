using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTargetItem : MonoBehaviour {

    public Camera mCamera;

    private bool isTarget;
    public bool isMouseTargetAwake { set; get; }
    private enum targetItem { passwordDoor };
    private targetItem nowTarget;
    private GameObject targetObject;
    private Renderer[] targetObjectRenderer;

    [SerializeField] private Material edgeMaterial;

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
                    targetObjectRenderer = targetObject.GetComponentsInChildren<Renderer>();
                    foreach (Renderer it in targetObjectRenderer)
                        it.material.EnableKeyword("_EMISSION");
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
                    default:
                        break;
                }
        } else {
            if (targetObject != null) {
                targetObjectRenderer = targetObject.GetComponentsInChildren<Renderer>();
                foreach (Renderer it in targetObjectRenderer)
                    it.material.DisableKeyword("_EMISSION");
            }
        }
    }
}
