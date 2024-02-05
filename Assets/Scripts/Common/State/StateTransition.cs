using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTransition
{
    private State targetState;
    private StateTransitionCondition condition;


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
