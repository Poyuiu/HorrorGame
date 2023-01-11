using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Subs : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI subtitleText = default;

    public static Subs instance;

    private void Awake()
    {
        instance = this;
    }

    public void SetSubtitle(string subtitle)
    {
        subtitleText.text = subtitle;
    }

    public void ClearSubtitile()
    {
        subtitleText.text = "";
    }

}
