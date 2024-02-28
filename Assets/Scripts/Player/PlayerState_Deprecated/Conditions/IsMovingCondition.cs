using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class IsMovingCondition : StateTransitionCondition_Deprecated
{
    public IsMovingCondition(State_Deprecated state) : base(state)
    {
    }

    public override bool EvaluateCondition()
    {
        Vector2 movement = InputManager.Instance.GetMovementDirectionVector();
        return !movement.Equals(Vector2.zero);
    }
}
