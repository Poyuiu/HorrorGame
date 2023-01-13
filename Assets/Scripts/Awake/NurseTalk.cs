using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NurseTalk : MonoBehaviour
{
    public AudioSource source;
    public AudioClip endsub2;
    public Subs subs;
    private const string mark_key_word_pre = "<mark=#ffffff44 padding=\"40,40,20,20\">";
    private const string mark_key_word_post = "</mark>";
    private void Start()
    {
        StartCoroutine(PleaseMyLasatFunction());
    }

    IEnumerator PleaseMyLasatFunction()
    {
        yield return new WaitForSeconds(7f);
        subs.SetSubtitle(
            mark_key_word_pre
            + "Sir, it's time to take medicine."
            + mark_key_word_post
            );
        source.PlayOneShot(endsub2);
        yield return new WaitForSeconds(3f);
        subs.ClearSubtitile();
    }
}
