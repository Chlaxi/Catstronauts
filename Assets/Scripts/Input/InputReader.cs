using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IFlightModeActions
{
    private Controls _controls;
    public event Action FireEvent;
    public Vector2 MovementValue { get; private set; }

    private void Start()
    {
        _controls = new Controls();
        _controls.FlightMode.SetCallbacks(this);
        _controls.FlightMode.Enable();
    }

    private void OnDestroy()
    {
        _controls.FlightMode.Disable();
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
