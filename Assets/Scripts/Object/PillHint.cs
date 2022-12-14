using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillHint : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];    
    }

    private void Update()
    {
        Vector3 targetPosition = new(
            player.transform.position.x,
            this.transform.position.y,
            player.transform.position.z);
        transform.LookAt(targetPosition);
        transform.Rotate(0f, 180f, 0f, Space.Self);
        //Debug.Log(transform.rotation);
    }
}
