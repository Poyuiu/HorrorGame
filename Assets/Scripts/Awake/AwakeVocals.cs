using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeVocals : MonoBehaviour
{
    public AudioSource source;
    public AudioClip endsub0;
    public AudioClip endswitch;
    public static AwakeVocals instance;


    public Subs subs;
    private List<string> subtitles;
    private List<float> subsKeepingTime;

    private int cur_sub_index;

    private const string mark_key_word_pre = "<mark=#ffffff44 padding=\"40,40,20,20\">";
    private const string mark_key_word_post = "</mark>";
    private const string hint_pre = "<size=60%>";
    private const string hint_post = "</size>";

    private void Awake()
    {
        instance = this;

        source = gameObject.AddComponent<AudioSource>();
        cur_sub_index = 0;
        subtitles = new List<string>
        {
            "God bless, fortunately it's just a dream."
        };
        subsKeepingTime = new List<float>
        {
        };
        //subs.SetSubtitle("123123");
    }

    private void Start()
    {
        StartCoroutine(SubsDisplay());
    }

    IEnumerator SubsDisplay()
    {
        yield return new WaitForSeconds(2.1f);
        source.PlayOneShot(endswitch);
        yield return new WaitForSeconds(2.5f);
        subs.SetSubtitle(
            mark_key_word_pre
            + subtitles[cur_sub_index]
            + mark_key_word_post
            );
        source.PlayOneShot(endsub0);
        yield return new WaitForSeconds(3f);
        subs.ClearSubtitile();
    }
}
