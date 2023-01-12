using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryState : MonoBehaviour
{
    // Start is called before the first frame update
    
    public bool[] pageState;
    public int maxPage;
    public int minPage;
    public bool debuging;
    void Awake()
    {
        maxPage = 3;
        minPage = 0;
        pageState = new bool[maxPage - minPage + 1];
        for(int i = minPage; i <= maxPage; i++)
            pageState[i] = debuging;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PickUpDiaryPage(int i)
    {
        pageState[i] = true;
        StartCoroutine(DiaryPickHint());
    }
    public bool IfPageCanBeShow(int p)
    {
        return pageState[p];
    }
    public IEnumerator DiaryPickHint()
    {
        yield return new WaitForSeconds(2.5f);
    }
}
