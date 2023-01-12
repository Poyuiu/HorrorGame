using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class NewspaperUI : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Image img;
    public Vector3 startPos;
    public uint newspaperNum;
    public bool canDrag = true;
    
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        img.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canDrag) transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = startPos;
        img.raycastTarget = true;
    }
}
