using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashExitCondition : StateTransitionCondition
{
    public DashExitCondition(PlayerDash state) : base(state)
    {
    }

    public override bool EvaluateCondition()
    {
        return ((PlayerDash)state).IsTimeExpired();
    }
}
