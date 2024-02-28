using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTransitionCondition_Deprecated
{
    protected State_Deprecated state;
    public StateTransitionCondition_Deprecated(State_Deprecated state)
    {
        this.state = state;
    }

    public virtual bool EvaluateCondition()
    {
        return false;
    }
}
