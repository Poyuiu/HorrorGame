using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    private bool hasTriggered = false;
    public GameObject Item;
    public Vector3 force;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("test");
            hasTriggered = true;
            Item.GetComponent<Rigidbody>().AddForce(force);
        }
    }
}
