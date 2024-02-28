using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerStateList_Deprecated
{
    Idle,
    Walk,
    Dash
}

public class PlayerStateContext : StateContext_Deprecated
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
    [SerializeField]
    private float rotationSpeed;

    private float dashCooldownCounter = 0;
    private CharacterController characterController;

    public Rigidbody RigidBodyComponet { get; private set; }
    public float MovementSpeed => movementSpeed;
    public float DashDuration => dashDuration;
    public float DashMultiplier => dashMultiplier;
    public float DashCooldown => dashCooldown;

    public float DashCooldownCounter => dashCooldownCounter;
    public AnimationCurve DashDecayCurve => dashDecayCurve;

    public CharacterController CharacterController => characterController;

    public float RotationSpeed => rotationSpeed;

    protected override void Initialize()
    {
        base.Initialize();
        characterController = GetComponent<CharacterController>();
        RigidBodyComponet = GetComponent<Rigidbody>();
        stateList[PlayerStateList_Deprecated.Idle] = new PlayerIdle_Deprecated(this);
        stateList[PlayerStateList_Deprecated.Walk] = new PlayerWalk_Deprecated(this);
        stateList[PlayerStateList_Deprecated.Dash] = new PlayerDash_Deprecated(this);

        List<StateTransition_Deprecated> idleTransitions = new List<StateTransition_Deprecated> {
            new StateTransition_Deprecated(
                StateList[PlayerStateList_Deprecated.Walk],
                new IsMovingCondition(stateList[PlayerStateList_Deprecated.Idle])
            )
        };

        List<StateTransition_Deprecated> walkTransition = new List<StateTransition_Deprecated> {
            new StateTransition_Deprecated(
                StateList[PlayerStateList_Deprecated.Idle],
                new IdleCondition(stateList[PlayerStateList_Deprecated.Walk])
            ),
            new StateTransition_Deprecated(
                StateList[PlayerStateList_Deprecated.Dash],
                new DashCondition((PlayerWalk_Deprecated)stateList[PlayerStateList_Deprecated.Walk])
            )
        };

        List<StateTransition_Deprecated> dashTransition = new List<StateTransition_Deprecated> {
            new StateTransition_Deprecated(
                StateList[PlayerStateList_Deprecated.Walk],
                new DashExitCondition((PlayerDash_Deprecated)StateList[PlayerStateList_Deprecated.Dash])
            )
        };

        stateList[PlayerStateList_Deprecated.Idle].SetupStansitions(idleTransitions);
        stateList[PlayerStateList_Deprecated.Walk].SetupStansitions(walkTransition);
        stateList[PlayerStateList_Deprecated.Dash].SetupStansitions(dashTransition);

        currentState = stateList[PlayerStateList_Deprecated.Idle];
    }

    public override void EnterState(State_Deprecated targetState)
    {
        if(targetState is PlayerDash_Deprecated)
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
