using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashCondition :StateTransitionCondition_Deprecated
{
    public DashCondition(PlayerWalk_Deprecated state) : base(state)
    {
    }

    public override bool EvaluateCondition()
    {
        return InputManager.Instance.IsDashedPressed() && ((PlayerWalk_Deprecated)state).IsDashReady();
    }
}
