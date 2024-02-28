using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashExitCondition : StateTransitionCondition_Deprecated
{
    public DashExitCondition(PlayerDash_Deprecated state) : base(state)
    {
    }

    public override bool EvaluateCondition()
    {
        return ((PlayerDash_Deprecated)state).IsTimeExpired();
    }
}
