using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryEntry : MonoBehaviour
{
    RectTransform rectTranform;
    // Start is called before the first frame update
    void Start()
    {
        rectTranform = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pointerEnter()
    {
        rectTranform.localScale = new Vector3(1.1f,1.1f,1f);
    }

    public void pointerLeave()
    {
        rectTranform.localScale = new Vector3(1f,1f,1f);
    }
}
