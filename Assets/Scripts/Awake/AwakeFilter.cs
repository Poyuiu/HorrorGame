using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AwakeFilter : MonoBehaviour
{
    public Image filter;
    public float fadeTime = 2f;
    private void Start()
    {
        StartCoroutine(Fading());
    }
    IEnumerator Fading()
    {
        for (int i = 100; i >= 0; i--)
        {
            filter.color = new Color(filter.color.r,
                filter.color.g, filter.color.b, i / 100f);
            yield return new WaitForSeconds(0.01f);
        }
        //Debug.Log(filter.color.a);
        //yield return new WaitForSeconds(15);
        //for (int i = 0; i <= 100; i++)
        //{
        //    filter.color = new Color(filter.color.r,
        //        filter.color.g, filter.color.b, i / 100f);
        //    yield return new WaitForSeconds(0.01f);
        //}
    }
}
