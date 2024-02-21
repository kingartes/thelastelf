using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : State
{
    private float dashCounter;
    private PlayerStateContext playerContext;
    private Vector2 dashDirection;


    public PlayerDash(PlayerStateContext playerContext) : base(playerContext)
    {
        this.playerContext = playerContext;
    }

    public override void Enter()
    {
        dashCounter = 0;
        dashDirection = InputManager.Instance.GetMovementDirectionVector();
        Debug.Log("Dash!!!");
    }

    public override void Exit()
    {

    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        dashCounter += Time.deltaTime;
        Debug.Log(dashDirection);
        Vector3 movementVector = new Vector3(dashDirection.x, 0, dashDirection.y);

        Vector3 velocityVector = movementVector * playerContext.MovementSpeed;
        velocityVector += movementVector * playerContext.DashMultiplier * playerContext.DashDecayCurve.Evaluate(dashCounter / playerContext.DashDuration) ;
        playerContext.CharacterController.Move(velocityVector * Time.deltaTime);
    }

    public bool IsTimeExpired()
    {
        return dashCounter > playerContext.DashDuration;
    }
}
