using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCondition : StateTransitionCondition
{
    public ChaseCondition(EnemyAttack state) : base(state)
    {
    }

    public override bool EvaluateCondition()
    {
        return !((EnemyAttack) state).IsTargetInRange();
    }
}
