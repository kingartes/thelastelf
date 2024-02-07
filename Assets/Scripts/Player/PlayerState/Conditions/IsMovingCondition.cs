using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class IsMovingCondition : StateTransitionCondition
{
    public IsMovingCondition(State state) : base(state)
    {
    }

    public override bool EvaluateCondition()
    {
        Vector2 movement = InputManager.Instance.GetMovementDirectionVector();
        return !movement.Equals(Vector2.zero);
    }
}
