using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCondition : StateTransitionCondition_Deprecated
{
    public ChaseCondition(EnemyAttack_Deprecated state) : base(state)
    {
    }

    public override bool EvaluateCondition()
    {
        return !((EnemyAttack_Deprecated) state).IsTargetInRange();
    }
}
