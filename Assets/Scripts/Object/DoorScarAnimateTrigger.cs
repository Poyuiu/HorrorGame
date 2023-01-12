using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScarAnimateTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    bool haveTrigger;
    public  SmallDoorScript door;
    void Start()
    {
        haveTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if(haveTrigger)
            return;
        if (other.gameObject.CompareTag("Player"))
        {
            haveTrigger = true;
            door.openDoor();
        }
    }
}
