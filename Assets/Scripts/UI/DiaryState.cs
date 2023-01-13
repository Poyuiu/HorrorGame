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

    private bool disPlayOneTime;
    public AudioClip forNull;
    public AudioClip sub4;
    public AudioClip sub5;

    void Awake()
    {
        maxPage = 3;
        minPage = 0;
        pageState = new bool[maxPage - minPage + 1];
        for (int i = minPage; i <= maxPage; i++)
            pageState[i] = debuging;
    }
    private void Start()
    {
        disPlayOneTime = true;
    }
    public void PickUpDiaryPage(int i)
    {
        pageState[i] = true;
        if (disPlayOneTime)
        {
            disPlayOneTime = false;
            StartCoroutine(ShowSubsWhenPickFirstDiary());
        }

    }
    public bool IfPageCanBeShow(int p)
    {
        return pageState[p];
    }

    IEnumerator ShowSubsWhenPickFirstDiary()
    {

        Vocals.instance.Say(sub4, 4);
        yield return new WaitForSeconds(1f);
        Vocals.instance.Say(sub5, 5);
        yield return new WaitForSeconds(2f);
        Vocals.instance.Say(forNull, 6);
    }
}
