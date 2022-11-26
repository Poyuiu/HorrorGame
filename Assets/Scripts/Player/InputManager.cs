using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] Movement movement;

    PlayerControls controls;
    PlayerControls.GroundMovementActions groundMovement;
    Vector2 horizontalInput;

    private void Awake()
    {
        controls = new PlayerControls();
        groundMovement = controls.GroundMovement;

        // groundMovement.[action].performd +=  context
        groundMovement.HorizontalMovement.performed += ctx => ctx.ReadValue<Vector2>();
    }

    private void Update()
    {
        movement.RecieveInput(horizontalInput);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();

    }
}
