using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateContext_Deprecated: MonoBehaviour
{
    protected State_Deprecated currentState;
    protected Dictionary<Enum, State_Deprecated> stateList;

    public Dictionary<Enum, State_Deprecated> StateList => stateList;

    protected virtual void Initialize()
    {
        stateList = new Dictionary<Enum, State_Deprecated>();
    }

    protected virtual void Awake()
    {
        Initialize();
    }

    protected virtual void Update()
    {
        currentState.OnUpdate();
    }

    public virtual void EnterState(State_Deprecated targetState)
    {
        currentState.Exit();
        currentState = targetState;
        currentState.Enter();
    }
}
