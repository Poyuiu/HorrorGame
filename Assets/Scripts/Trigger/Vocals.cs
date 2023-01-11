using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vocals : MonoBehaviour
{
    private AudioSource source;

    public static Vocals instance;
    public Subs subs;
    private List<string> subtitles;
    private List<float> subsKeepingTime;

    private int cur_sub_index;
    private bool cont;

    private const string mark_key_word_pre = "<mark=#ffffff44 padding=\"40,40,20,20\">";
    private const string mark_key_word_post = "</mark>";
    private const string hint_pre = "<size=60%>";
    private const string hint_post = "</size>";

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        cur_sub_index = 0;
        cont = false;
        subtitles = new List<string>
        {
            "Why am I here?",
            hint_pre +
            "(Press Right Mouse Button to Switch the Flashlight)"+
            hint_post,
        };
        subsKeepingTime = new List<float>
        {
            2f,
            1f,
        };
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
            cont = true;
    }

    public void Say(AudioClip clip)
    {
        if (source.isPlaying)
            source.Stop();

        source.PlayOneShot(clip);
        //Debug.Log("Hi I am here");
        if (cur_sub_index >= subtitles.Count)
            return;
        //Debug.Log("Hi I am Here");
        Subs.instance.SetSubtitle(
            mark_key_word_pre
            + subtitles[cur_sub_index]
            + mark_key_word_post
            );
        StartCoroutine(WaitForSubsDisplay());
    }

    IEnumerator WaitForSubsDisplay()
    {
        if (cur_sub_index == 1)
            yield return new WaitUntil(() => cont);
        yield return new WaitForSeconds(subsKeepingTime[cur_sub_index]);
        cur_sub_index += 1;
        subs.ClearSubtitile();
    }

}
