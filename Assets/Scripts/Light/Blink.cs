using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    private bool complete = true;
    private Light l;
    private Material m;
    // Start is called before the first frame update
    void Start()
    {
        l = transform.GetChild(0).GetComponent<Light>();
        m = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (complete) 
            StartCoroutine(this.lightSparkle());
    }
    IEnumerator lightSparkle()
    {
        complete = false;
        yield return new WaitForSeconds(Random.Range(0.5f, 2f));
        l.enabled = false;
        m.SetColor("_EmissiveColor", new Color(0, 0, 0));
        yield return new WaitForSeconds(Random.Range(0.1f, 2f));
        l.enabled = true;
        m.SetColor("_EmissiveColor", new Color(0.541f, 0.792f, 0.302f));
        yield return new WaitForSeconds(Random.Range(0.05f, 0.1f));
        l.enabled = false;
        m.SetColor("_EmissiveColor", new Color(0, 0, 0));
        yield return new WaitForSeconds(Random.Range(0.05f, 0.1f));
        l.enabled = true;
        m.SetColor("_EmissiveColor", new Color(0.541f, 0.792f, 0.302f));
        complete = true;
    }
}
