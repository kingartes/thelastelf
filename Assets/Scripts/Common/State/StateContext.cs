using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateContext: MonoBehaviour
{
    protected State currentState;
    protected Dictionary<Enum, State> stateList;

    public Dictionary<Enum, State> StateList => stateList;

    protected virtual void Initialize()
    {
        stateList = new Dictionary<Enum, State>();
    }

    protected virtual void Awake()
    {
        Initialize();
    }

    protected virtual void Update()
    {
        currentState.OnUpdate();
    }

    public virtual void EnterState(State targetState)
    {
        currentState.Exit();
        currentState = targetState;
        currentState.Enter();
    }
}
