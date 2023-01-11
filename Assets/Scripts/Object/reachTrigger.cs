using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reachTrigger : MonoBehaviour
{
    public GameObject pic2;
    public Material modifiedMaterial;
    public AudioClip SE1;
    public AudioClip SE2;
    public AudioSource audioSrc;
    private MeshRenderer pic2Renderer;


    // Start is called before the first frame update
    void Start()
    {
        pic2Renderer = pic2.GetComponent<MeshRenderer> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        // modify Pic2 Texture
        audioSrc.PlayOneShot(SE1);
        pic2Renderer.material = modifiedMaterial;
        audioSrc.PlayOneShot(SE2);
        // pic2Renderer.material.SetTexture("_MainTex", modifiedTexture);
        // Debug.Log("pass through pic2");
        Destroy(GetComponent<BoxCollider>());
    }
}
