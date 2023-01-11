using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryPageControl : MonoBehaviour
{
    public int pageID;
    public GameObject diaryPickSys;
    DiaryState diaryState;
    // Start is called before the first frame update
    void Start()
    {
        diaryState = diaryPickSys.GetComponent<DiaryState>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pick()
    {
        diaryState.PickUpDiaryPage(pageID);
    }
}
