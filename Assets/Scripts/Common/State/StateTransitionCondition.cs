using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTransitionCondition
{
    protected State state;
    public StateTransitionCondition(State state)
    {
        this.state = state;
    }

    public virtual bool EvaluateCondition()
    {
        return false;
    }
}
