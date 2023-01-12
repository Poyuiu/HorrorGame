using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewspaperFloor : MonoBehaviour
{
    [SerializeField] uint newspaperNum;
    [SerializeField] BoardUI boardUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && NearView())
        {
            boardUI.pickNewspaper(newspaperNum);
            Destroy(gameObject);
        }
    }
    bool NearView()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector3 direction = transform.position - Camera.main.transform.position;
        float angleView = Vector3.Angle(Camera.main.transform.forward, direction);
        if (angleView < 60f && distance < 3f) return true;
        else return false;
    }
}
