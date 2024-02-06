using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashCondition :StateTransitionCondition
{
    public DashCondition(PlayerWalk state) : base(state)
    {
    }

    public override bool EvaluateCondition()
    {
        return InputManager.Instance.IsDashedPressed() && ((PlayerWalk)state).IsDashReady();
    }
}
