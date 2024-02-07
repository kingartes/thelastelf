using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : State
{
    private float dashCounter;
    private PlayerStateContext playerContext;


    public PlayerDash(PlayerStateContext playerContext) : base(playerContext)
    {
        this.playerContext = playerContext;
    }

    public override void Enter()
    {
        dashCounter = 0;
    }

    public override void Exit()
    {

    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        dashCounter += Time.deltaTime;
        Vector2 movementDirection = InputManager.Instance.GetMovementDirectionVector();
        Vector3 movementVector = new Vector3(movementDirection.x, 0, movementDirection.y);

        Vector3 velocityVector = movementVector * playerContext.MovementSpeed;
        velocityVector += movementVector * playerContext.DashMultiplier * playerContext.DashDecayCurve.Evaluate(dashCounter / playerContext.DashDuration);
        playerContext.RigidBodyComponet.velocity = velocityVector;
    }

    public bool IsTimeExpired()
    {
        return dashCounter > playerContext.DashDuration;
    }
}
