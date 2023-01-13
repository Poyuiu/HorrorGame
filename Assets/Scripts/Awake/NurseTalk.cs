using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NurseTalk : MonoBehaviour
{
    public AudioSource source;
    public AudioClip endsub2;
    public AudioClip endse;
    public Subs subs;
    public Image filter;
    private const string mark_key_word_pre = "<mark=#ffffff44 padding=\"40,40,20,20\">";
    private const string mark_key_word_post = "</mark>";
    private void Start()
    {
        StartCoroutine(PleaseMyLasatFunction());
    }

    IEnumerator PleaseMyLasatFunction()
    {
        yield return new WaitForSeconds(9f);
        source.volume = 0.2f;
        source.PlayOneShot(endse);
        yield return new WaitForSeconds(2.8f);
        subs.SetSubtitle(
            mark_key_word_pre
            + "Sir, it's time to take medicine."
            + mark_key_word_post
            );
        source.volume = 1f;
        source.PlayOneShot(endsub2);
        yield return new WaitForSeconds(3f);
        for (int i = 0; i <= 100; i++)
        {
            filter.color = new Color(filter.color.r,
                filter.color.g, filter.color.b, i / 100f);
            yield return new WaitForSeconds(0.01f);
        }
        subs.ClearSubtitile();
    }
}
