using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoardUI : MonoBehaviour, IDropHandler
{
    [SerializeField] private GameObject realNewspapers1, realNewspapers2, realNewspapers3, realNewspapers4;
    [SerializeField] private GameObject[] UINewspaper = new GameObject[5];
    [SerializeField] private GameObject[] slots = new GameObject[5];
    [SerializeField] private BlackBoard realBlackBoard;
    private bool[] newspaperPicked = new bool[5] { false, false, false, false, false};

    // Update is called once per frame
    public void OnEnable()
    {
        int startX = -700;
        for (int i = 1; i <= 4; i++)
        {
            if (newspaperPicked[i])
            {
                UINewspaper[i].transform.position = UINewspaper[i].GetComponent<NewspaperUI>().startPos = new Vector2(startX + 960, 400 + 540);
                startX += 250;
            }
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        NewspaperUI newspaper = eventData.pointerDrag.GetComponent<NewspaperUI>();
        RectTransform rectTransform = eventData.pointerDrag.GetComponent<RectTransform>();
        if (newspaper != null)
        {
            switch (newspaper.newspaperNum)
            {
                case 1:
                    newspaper.startPos = new Vector2(-584 + 960, 0 + 540);
                    realNewspapers1.SetActive(true);
                    slots[1].SetActive(false);
                    break;
                case 2:
                    newspaper.startPos = new Vector2(-166 + 960, -239 + 540);
                    realNewspapers2.SetActive(true);
                    slots[2].SetActive(false);
                    break; 
                case 3:
                    newspaper.startPos = new Vector2(200 + 960, 36 + 540);
                    realNewspapers3.SetActive(true);
                    slots[3].SetActive(false);
                    break;
                case 4:
                    newspaper.startPos = new Vector2(615 + 960, -129 + 540);
                    realNewspapers4.SetActive(true);
                    slots[4].SetActive(false);
                    break;
                default:
                    return;
            }
            realBlackBoard.showNewspaper(newspaper.newspaperNum);
            newspaperPicked[newspaper.newspaperNum] = false;
        }
        if (rectTransform != null)
        {
            rectTransform.sizeDelta = new Vector2(450, 450);
        }
        newspaper.canDrag = false;
    }

    public void pickNewspaper(uint newspaperNum)
    {
        newspaperPicked[newspaperNum] = true;
        UINewspaper[newspaperNum].SetActive(true);
    }
}
