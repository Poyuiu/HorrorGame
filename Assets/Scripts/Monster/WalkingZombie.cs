using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingZombie : MonoBehaviour
{   
    private float countdown = 5;
    public bool is_walking = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (is_walking)
        {
            this.transform.position += new Vector3(0, 0, 7.5f) * Time.deltaTime;
            countdown -= Time.deltaTime;
            if (countdown <= 0.0f)
            {
                is_walking = false;
                Destroy(gameObject);
            }

        }
    }
}
