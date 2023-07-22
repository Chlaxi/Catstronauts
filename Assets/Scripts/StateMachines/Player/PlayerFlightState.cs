using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlightState : PlayerBaseState
{

    public PlayerFlightState(PlayerStateMachine stateMachine) : base(stateMachine){ }

    // Start is called before the first frame update
    public override void Tick(float deltaTime)
    {
        Vector3 direction = CalculateMovement();
        if(!BoundsCheck(stateMachine.Transform.position))
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

    private Vector3 CalculateMovement(){
        Vector3 direction = stateMachine.InputReader.MovementValue;
        Vector3 position = stateMachine.Transform.position;
        Bounds bounds = GameController.Instance.Bounds;
        if(position.y <= 0 && direction.y < bounds.Bottom|| position.y >= bounds.Top && direction.y > 0){
            direction.y = 0;
        }
        if(position.x <= bounds.Left && direction.x < 0 || position.x >= bounds.Right && direction.x > 0){
            direction.x = 0;
        } 
        direction.Normalize();
        return direction;
    }

    private bool BoundsCheck(Vector3 position){
        Bounds bounds = GameController.Instance.Bounds;
        if(position.y <= bounds.Top && position.y >= bounds.Bottom &&
            position.x <= bounds.Right && position.x >= bounds.Left)
            return false;

        Vector3 correctionVector = stateMachine.Transform.position;
        if(position.y > bounds.Top)
            correctionVector.y = bounds.Top;
        if(position.y < bounds.Bottom)
            correctionVector.y = bounds.Bottom;
        if(position.x > bounds.Right)
            correctionVector.x = bounds.Right;
        if(position.x < bounds.Left)
            correctionVector.x = bounds.Left;

        Debug.Log("Correcting position from out of bounds"+correctionVector.ToString());
        stateMachine.Transform.position = correctionVector;
        return true;
    }

    private void Fire()
    {    
        Debug.Log("Pew pew");
    }

}
