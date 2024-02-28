using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerWalk_Deprecated : State_Deprecated
{

    private PlayerStateContext playerContext;

    public PlayerWalk_Deprecated(PlayerStateContext playerContext) : base(playerContext)
    {
        this.playerContext = playerContext;

    }

    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        Vector2 movementDirection = InputManager.Instance.GetMovementDirectionVector();
        Vector3 movementVector = new Vector3(movementDirection.x, 0, movementDirection.y);

        Vector3 velocityVector = movementVector * playerContext.MovementSpeed * Time.deltaTime;
        playerContext.CharacterController.Move(velocityVector);
        playerContext.transform.forward = Vector3.Slerp(playerContext.transform.forward, movementVector, Time.deltaTime * playerContext.RotationSpeed);
    }

    public bool IsDashReady()
    {
        return playerContext.DashCooldownCounter <= 0;
    }

}
