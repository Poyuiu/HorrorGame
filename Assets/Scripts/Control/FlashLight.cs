using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] private GameObject mLight;
    private void Start()
    {
        mLight.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetMouseButtonDown(1))
            mLight.SetActive(!mLight.activeSelf);
    }
}
