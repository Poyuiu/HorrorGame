using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
#pragma warning disable IDE0052 // 刪除未讀取的私用成員
    private new Rigidbody rigidbody;
#pragma warning restore IDE0052 // 刪除未讀取的私用成員
    private readonly float jumpForce = 7f;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log(transform.position);
        }
    }
}
