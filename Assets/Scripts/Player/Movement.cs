using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector2 horizontalInput;

    public void RecieveInput( Vector2 _horizontalInput)
    {
        horizontalInput = _horizontalInput;
        Debug.Log(horizontalInput);
    }
}
