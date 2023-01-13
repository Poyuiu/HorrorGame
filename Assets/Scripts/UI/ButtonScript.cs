using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{

    public GameObject HelpCanvas, Title, StartBut, HelpBut, ExitBut;
    public AudioSource AS;
    public AudioClip clickSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) closeHelp();
    }

    void closeHelp()
    {
        Title.SetActive(true);
        StartBut.SetActive(true);
        ExitBut.SetActive(true);
        HelpBut.SetActive(true);
        HelpCanvas.SetActive(false);
    } 

    public void onQuit() {
        Application.Quit();
    }

    public void onHelp()
    {
        Title.SetActive(false);
        StartBut.SetActive(false);
        ExitBut.SetActive(false);
        HelpBut.SetActive(false);
        HelpCanvas.SetActive(true);
    }

    public void onCloseHelp() {
        closeHelp();
    }

    public void onStart() {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Stage1");
    }

    public void playClickSound() {
        AS.PlayOneShot(clickSound);
    }

}
