using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vocals : MonoBehaviour
{
    private AudioSource source;

    public static Vocals instance;

    public FPController fPController;

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

            "Uh... My head hurts.",

            "Why I can't remember anything",

            "Skip it. I have to find a way to leave here first.",

            "What is it?",

            "This handwriting seems familiar...",

            hint_pre +
            "(Press Tab to Open Diary Interface)"+
            hint_post,

            hint_pre +
            "(Press Right Mouse Button to Switch the Flashlight)"+
            hint_post,
        };
        subsKeepingTime = new List<float>
        {
            // why am
            1.5f,
            // head hurt
            2f,
            // can't remember
            2f,
            // skip it
            3f,
            // what is it
            1f,
            // this handwriting
            2f,

        };
    }
    private void Update()
    {
        if (cur_sub_index == 1 && Input.GetMouseButtonDown(1))
            cont = true;
    }

    public void Say(AudioClip clip)
    {
        if (source.isPlaying)
            source.Stop();

        source.PlayOneShot(clip);

        if (cur_sub_index >= subtitles.Count)
            return;

        StartCoroutine(SubsDisplay());
    }

    IEnumerator SubsDisplay()
    {
        if (cur_sub_index <= 3)
            fPController.LockMove();

        Subs.instance.SetSubtitle(
            mark_key_word_pre
            + subtitles[cur_sub_index]
            + mark_key_word_post
            );
        //if (cur_sub_index == 1)
        //    yield return new WaitUntil(() => cont);
        yield return new WaitForSeconds(subsKeepingTime[cur_sub_index]);

        if (cur_sub_index <= 3)
            fPController.UnlockMove();

        cur_sub_index += 1;
        subs.ClearSubtitile();

    }

}
