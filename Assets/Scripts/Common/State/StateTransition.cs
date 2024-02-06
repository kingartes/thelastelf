using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTransition
{
    protected State targetState;
    protected StateTransitionCondition condition;


    public StateTransition(State targetState, StateTransitionCondition condition)
    {
        this.targetState = targetState;
        this.condition = condition;
    }

    public bool TryEnterState(out State state)
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
