using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public InputReader InputReader {get; private set;}
    public Transform Transform {get; private set;}
    [field: SerializeField] public float BaseMovementSpeed {get; private set;}

    void Start()
    {
        Transform = transform;
        SwitchState(new PlayerFlightState(this));
    }


}
