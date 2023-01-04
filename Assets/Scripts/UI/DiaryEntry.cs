using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryEntry : MonoBehaviour
{
    RectTransform rectTranform;
    public GameObject diary;
    public bool diaryState;

    void Start()
    {
        rectTranform = gameObject.GetComponent<RectTransform>();
        diaryState = false;
        diary.SetActive(diaryState);
    }

    public void PointerEnter()
    {
        rectTranform.localScale = new Vector3(1.1f, 1.1f, 1f);
    }

    public void PointerLeave()
    {
        rectTranform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void PointerClick()
    {
        diaryState = !diaryState;
        diary.SetActive(diaryState);
    }

    public void CloseManually()
    {
        diaryState = false;
        diary.SetActive(diaryState);
    }
}
