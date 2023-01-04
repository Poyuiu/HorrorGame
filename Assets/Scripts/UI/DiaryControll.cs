using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DiaryControll : MonoBehaviour
{
    public GameObject rightCorner;
    public GameObject leftCorner;
    public void ShowRightCorner()
    {
        //Debug.Log("show right");
        //Debug.Log(rightCorner.name);
        rightCorner.SetActive(true);
    }
    public void HideRightCorner()
    {
        rightCorner.SetActive(false);
    }
    public void ShowLeftCorner()
    {
        leftCorner.SetActive(true);
    }
    public void HideLeftCorner()
    {
        leftCorner.SetActive(false);
    }
}
