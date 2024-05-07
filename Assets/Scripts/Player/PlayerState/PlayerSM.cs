using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSM : StateMachine<Player>
{
    private PlayerMovement playerMovement;

    private float dashCooldownCounter = 0;

    public PlayerSM(PlayerMovement playerMovement) : base (PlayerStateList.IDLE) {
        this.playerMovement = playerMovement;
    }

    protected override Dictionary<string, State> InitializeStates()
    {
        Dictionary<string, State> playerMovementStates = new Dictionary<string, State> { };
        playerMovementStates.Add(PlayerStateList.IDLE, new PlayerIdle());
        playerMovementStates.Add(PlayerStateList.WALKING, new PlayerWalk(playerMovement));
        playerMovementStates.Add(PlayerStateList.DASH, new PlayerDash(playerMovement, SetDashCooldown));


        AddTransition(playerMovementStates[PlayerStateList.IDLE], playerMovementStates[PlayerStateList.WALKING], () => IsMoving());
        AddTransition(playerMovementStates[PlayerStateList.WALKING], playerMovementStates[PlayerStateList.IDLE], () => !IsMoving());
        AddTransition(playerMovementStates[PlayerStateList.WALKING], playerMovementStates[PlayerStateList.DASH], () => IsStartDash());

        return playerMovementStates;
    }

    public override void OnLogic()
    {
        base.OnLogic();
        UpdateCooldown();
    }

    private void UpdateCooldown()
    {
        dashCooldownCounter = Mathf.Max(dashCooldownCounter - Time.deltaTime, 0);
    }

    private void SetDashCooldown()
    {
        dashCooldownCounter = playerMovement.DashCooldown;
    }

    private bool IsMoving()
    {
        Vector2 movement = InputManager.Instance.GetMovementDirectionVector();
        return !movement.Equals(Vector2.zero);
    }

    private bool IsStartDash()
    {
        return InputManager.Instance.IsDashedPressed() && IsDashReady();
    }

    private bool IsDashReady()
    {
        return dashCooldownCounter <= 0;
    }
}