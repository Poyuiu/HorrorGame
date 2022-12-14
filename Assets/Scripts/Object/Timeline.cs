using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timeline : MonoBehaviour
{
    public float maxTime = 30f;
    private float timeRemaining;
    public Image timeLine;

    private void Start()
    {
        timeRemaining = maxTime;
    }

    private void Update()
    {
        if (timeRemaining > 0f)
        {
            timeRemaining -= Time.deltaTime;
            timeLine.fillAmount = timeRemaining / maxTime;
        }
    }
}
