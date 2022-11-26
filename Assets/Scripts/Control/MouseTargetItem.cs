using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTargetItem : MonoBehaviour {

    public Camera mCamera;

    private bool isTarget;

    private GameObject targetObject;
    private Renderer[] targetObjectRenderer;

    [SerializeField] private Material edgeMaterial;

    void Start() {
        this.isTarget = false;
    }
    void Update() {

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

        if (!this.isTarget) {
            targetObjectRenderer = targetObject.GetComponentsInChildren<Renderer>();
            foreach (Renderer it in targetObjectRenderer)
                it.material.DisableKeyword("_EMISSION");
        }
    }
}
