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
            // 0
            "Why am I here?",
            //1
            "Uh... My head hurts.",
            //2
            "Why I can't remember anything",
            //3
            "Skip it. I have to find a way to leave here first.",
            //4
            "What is it?",
            //5
            "This handwriting seems familiar...",
            //6
            hint_pre +
            "(Press Tab to Open/Close Diary Interface)"+
            hint_post,
            //7
            hint_pre +
            "(Press Right Mouse Button to Switch the Flashlight)"+
            hint_post,
            //8
            "It is ... medicine?",
            //9
            "Why is here?",
            //10
            "This place is getting spooky...",
            //11
            "Well, it's locked...",
            //12
            "But what's the password?",
            //13
            "Argh, my head is so pained.",
            //14
            "Hope that the jar of pills were painkillers.",
        };
        subsKeepingTime = new List<float>
        {
            // 0
            1.5f,
            // 1
            2f,
            // 2
            2f,
            // 3
            3f,
            // 4
            1f,
            // 5
            2f,
            // 6
            1f,
            // 7
            1f,
            // 8
            2f,
            // 9
            1f,
            //10
            2.5f,
            //11
            2f,
            //12
            1.5f,
            //13
            2f,
            //14
            2.5f,
        };
    }
    private void Update()
    {
        if (cur_sub_index == 6 && Input.GetKeyDown(KeyCode.Tab)) cont = true;
        if (cur_sub_index == 7 && Input.GetMouseButtonDown(1)) cont = true;
    }

    public void Say(AudioClip clip, int _cur_sub_index)
    {
        if (source.isPlaying)
            source.Stop();

        source.PlayOneShot(clip);

        cur_sub_index = _cur_sub_index;
        if (cur_sub_index >= subtitles.Count)
            return;

        this.cont = false;
        StartCoroutine(SubsDisplay());
    }

    IEnumerator SubsDisplay()
    {
        if (cur_sub_index <= 6)
            fPController.LockMove();

        //if (cur_sub_index == 7)
        //    Debug.Log(cur_sub_index.ToString() + ": " + cont.ToString());
        Subs.instance.SetSubtitle(
            mark_key_word_pre
            + subtitles[cur_sub_index]
            + mark_key_word_post
            );

        if (cur_sub_index == 6 || cur_sub_index == 7)
        {
            yield return new WaitUntil(() => cont);
        }
        //if (cur_sub_index == 6)
        //    Debug.Log(cur_sub_index.ToString()+ ": " +cont.ToString());
        yield return new WaitForSeconds(subsKeepingTime[cur_sub_index]);

        if (cur_sub_index <= 6)
            fPController.UnlockMove();

        //cur_sub_index += 1;
        subs.ClearSubtitile();

    }

}
