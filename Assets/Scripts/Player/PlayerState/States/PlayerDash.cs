using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerDash : State
{
    private float dashCounter;
    private PlayerMovement playerMovement;
    private Vector2 dashDirection;
    private Action setDashCooldownCounter;


    public PlayerDash(PlayerMovement playerMovement, Action setDashCooldownCounter) : base(PlayerStateList.DASH)
    {
        this.playerMovement = playerMovement;
        this.setDashCooldownCounter = setDashCooldownCounter;
    }

    public override void OnEnter()
    {
        dashCounter = 0;
        dashDirection = InputManager.Instance.GetMovementDirectionVector();
        setDashCooldownCounter();
    }

    public override void OnLogic()
    {
        base.OnLogic();
        dashCounter += Time.deltaTime;
        Debug.Log(dashDirection);
        Vector3 movementVector = new Vector3(dashDirection.x, 0, dashDirection.y);

        Vector3 velocityVector = movementVector * playerMovement.MovementSpeed;
        velocityVector += movementVector * playerMovement.DashMultiplier * playerMovement.DashDecayCurve.Evaluate(dashCounter / playerMovement.DashDuration);
        playerMovement.CharacterController.Move(velocityVector * Time.deltaTime);

        CheckExperation();
    }

    public void CheckExperation()
    {
        if (dashCounter > playerMovement.DashDuration)
        {
            RequestExit();
        }
    }
}

