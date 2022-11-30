using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingPills : MonoBehaviour
{
    public Canvas hints_1;
    public SceneLoader loader;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Medicine"))
        {
            Debug.Log("can pick");
            hints_1.enabled = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Medicine")
            && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(other.gameObject);

            // decrease sanity
            // call scene changing
            hints_1.enabled = false;
            StartCoroutine(loader.ChangeScene());
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Medicine"))
        {
            Debug.Log("can't pick");
            hints_1.enabled = false;
        }
    }
}
