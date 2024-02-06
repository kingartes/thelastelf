using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerStateList 
{
    Idle,
    Walk,
    Dash
}

public class PlayerStateContext : StateContext
{
    [SerializeField]
    private float movementSpeed = 10f;
    [SerializeField]
    private float dashDuration = 1f;
    [SerializeField]
    private float dashMultiplier = 5f;
    [SerializeField]
    private float dashCooldown = 1f;
    [SerializeField]
    private AnimationCurve dashDecayCurve;

    private float dashCooldownCounter = 0;

    public Rigidbody RigidBodyComponet { get; private set; }
    public float MovementSpeed => movementSpeed;
    public float DashDuration => dashDuration;
    public float DashMultiplier => dashMultiplier;
    public float DashCooldown => dashCooldown;

    public float DashCooldownCounter => dashCooldownCounter;
    public AnimationCurve DashDecayCurve => dashDecayCurve;

    protected override void Initialize()
    {
        base.Initialize();
        RigidBodyComponet = GetComponent<Rigidbody>();
        stateList[PlayerStateList.Idle] = new PlayerIdle(this);
        stateList[PlayerStateList.Walk] = new PlayerWalk(this);
        stateList[PlayerStateList.Dash] = new PlayerDash(this);

        List<StateTransition> idleTransitions = new List<StateTransition> {
            new StateTransition(
                StateList[PlayerStateList.Walk],
                new IsMovingCondition(stateList[PlayerStateList.Idle])
            )
        };

        List<StateTransition> walkTransition = new List<StateTransition> {
            new StateTransition(
                StateList[PlayerStateList.Idle],
                new IdleCondition(stateList[PlayerStateList.Walk])
            ),
            new StateTransition(
                StateList[PlayerStateList.Dash],
                new DashCondition((PlayerWalk)stateList[PlayerStateList.Walk])
            )
        };

        List<StateTransition> dashTransition = new List<StateTransition> {
            new StateTransition(
                StateList[PlayerStateList.Walk],
                new DashExitCondition((PlayerDash)StateList[PlayerStateList.Dash])
            )
        };

        stateList[PlayerStateList.Idle].SetupStansitions(idleTransitions);
        stateList[PlayerStateList.Walk].SetupStansitions(walkTransition);
        stateList[PlayerStateList.Dash].SetupStansitions(dashTransition);

        currentState = stateList[PlayerStateList.Idle];
    }

    public override void EnterState(State targetState)
    {
        if(targetState is PlayerDash)
        {
            dashCooldownCounter = dashCooldown;
        }
        base.EnterState(targetState);
    }

    protected override void Update()
    {
        base.Update();
        dashCooldownCounter = Mathf.Clamp(dashCooldownCounter - Time.deltaTime, 0, dashCooldown);
    }
}
