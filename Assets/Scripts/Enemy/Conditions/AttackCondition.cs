using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCondition : StateTransitionCondition
{
    public AttackCondition(EnemyChase state) : base(state)
    {
    }

    public override bool EvaluateCondition()
    {
        return ((EnemyChase) state).IsTargetInRange();
    }
}
