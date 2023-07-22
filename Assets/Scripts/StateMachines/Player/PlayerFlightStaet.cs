using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlightState : PlayerBaseState
{

    public PlayerFlightState(PlayerStateMachine stateMachine) : base(stateMachine){ }

    // Start is called before the first frame update
    public override void Tick(float deltaTime)
    {
        Vector2 direction = CalculateMovement();
        stateMachine.Transform.Translate(direction * stateMachine.BaseMovementSpeed * deltaTime);
    }

    public override void Enter()
    {
        Debug.Log("Enter flight state");
        stateMachine.InputReader.FireEvent += Fire;
    }

    public override void Exit()
    {
        Debug.Log("Exit flight state");
        stateMachine.InputReader.FireEvent -= Fire;
    }

    private Vector2 CalculateMovement(){
        Vector2 direction = stateMachine.InputReader.MovementValue.normalized;
        return direction;
    }

    private void Fire()
    {    
        Debug.Log("Pew pew");
    }

}
