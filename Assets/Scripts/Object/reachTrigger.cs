using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reachTrigger : MonoBehaviour
{
    public GameObject pic2;
    public Texture modifiedTexture;
    private Renderer pic2Renderer;

    // Start is called before the first frame update
    void Start()
    {
        pic2Renderer = pic2.GetComponent<Renderer> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        // modify Pic2 Texture
        // pic2Renderer.material.SetTexture("_MainTex", modifiedTexture);
        Debug.Log("pass through pic2");
        Destroy(GetComponent<BoxCollider>());
    }
}
