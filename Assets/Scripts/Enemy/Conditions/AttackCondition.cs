using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCondition : StateTransitionCondition_Deprecated
{
    public AttackCondition(EnemyChase_Deprecated state) : base(state)
    {
    }

    public override bool EvaluateCondition()
    {
        return ((EnemyChase_Deprecated) state).IsTargetInRange();
    }
}
