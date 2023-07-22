using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IFlightModeActions
{
    private Controls controls;
    public event Action FireEvent;
    public Vector2 MovementValue { get; private set; }

    private void Start()
    {
        controls = new Controls();
        controls.FlightMode.SetCallbacks(this);
        controls.FlightMode.Enable();
    }

    private void OnDestroy()
    {
        controls.FlightMode.Disable();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;
        
        FireEvent?.Invoke();
    }
    
        public void OnMovement(InputAction.CallbackContext context){
        MovementValue = context.ReadValue<Vector2>();
    }


}
