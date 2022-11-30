using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timeline : MonoBehaviour
{
    public float maxTime = 5f;
    private float timeRemaining;
    public Image timeLine;

    private void Start()
    {
        timeRemaining = maxTime;
    }

    private void Update()
    {
        Debug.Log(timeRemaining);
        if (timeRemaining > 0f)
        {
            timeRemaining -= Time.deltaTime;
            timeLine.fillAmount = timeRemaining / maxTime;
        }
    }
}
