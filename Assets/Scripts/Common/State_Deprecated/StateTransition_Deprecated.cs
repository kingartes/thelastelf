using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTransition_Deprecated
{
    protected State_Deprecated targetState;
    protected StateTransitionCondition_Deprecated condition;


    public StateTransition_Deprecated(State_Deprecated targetState, StateTransitionCondition_Deprecated condition)
    {
        this.targetState = targetState;
        this.condition = condition;
    }

    public bool TryEnterState(out State_Deprecated state)
    {
        state = null;
        if (condition.EvaluateCondition())
        {
            state = targetState;
            return true;
        }
        return false;
    }
}
