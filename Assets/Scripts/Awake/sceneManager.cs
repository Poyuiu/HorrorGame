using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public GameObject focusOn;
    public float Speed = 1;
    public float desiredTime1 = 5.0f;
    public float desiredTime2 = 16.0f;
    private float timer = 0;

    void Start() {
        desiredTime1 = 6.0f;
        desiredTime2 = 15f;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= desiredTime1)
        {
            focusOn.transform.localPosition = Vector3.MoveTowards(focusOn.transform.localPosition, new Vector3(-14.974f, 0.879f, 4.754f), Speed*Time.deltaTime);
        }
        if (timer >= desiredTime2)
        {
            SceneManager.LoadScene("Menu");
        }
    }

}
