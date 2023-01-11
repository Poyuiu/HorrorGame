using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class DiaryControll : MonoBehaviour
{
    public GameObject rightCorner;
    public GameObject leftCorner;
    public GameObject diaryPickSys;

    DiaryState diaryState;
    int nowInPage;
    int maxPage;
    int minPage;
    public GameObject[] pageList;
    void Start() {
        diaryState = diaryPickSys.GetComponent<DiaryState>();
        maxPage = diaryState.maxPage;
        minPage = diaryState.minPage;
        nowInPage = minPage;
        ShowAPage(nowInPage);
    }
    void Update() {
    }
    private void ShowAPage(int p)
    {
        if(diaryState.IfPageCanBeShow(p))
            pageList[p].SetActive(true);
    }
    private void HideAPage(int p)
    {
        pageList[p].SetActive(false);
    }
    public void ShowRightCorner()
    {
        //Debug.Log("show right");
        //Debug.Log(rightCorner.name);
        if(nowInPage == maxPage) return;
        rightCorner.SetActive(true);
    }
    public void HideRightCorner()
    {
        rightCorner.SetActive(false);
    }
    public void ShowLeftCorner()
    {
        if(nowInPage == minPage) return;
        leftCorner.SetActive(true);
    }
    public void HideLeftCorner()
    {
        leftCorner.SetActive(false);
    }
    public void ToNextPage()
    {
        HideAPage(nowInPage);
        nowInPage++;
        if(nowInPage > maxPage)
            nowInPage = maxPage;
        ShowAPage(nowInPage);
        if(nowInPage == maxPage)
            HideRightCorner();
    }
    public void ToPreviousPage()
    {
        HideAPage(nowInPage);
        nowInPage--;
        if(nowInPage < minPage)
            nowInPage = minPage;
        ShowAPage(nowInPage);
        if(nowInPage == minPage)
            HideLeftCorner();
    }
}
