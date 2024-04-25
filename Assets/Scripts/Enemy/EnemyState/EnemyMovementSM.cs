using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovementSM : StateMachine<EnemyAI>
{
    private EnemyAI enemyAI;


    public EnemyMovementSM(EnemyAI enemyAI) : base(EnemyStateList.IDLE)
    {
        this.enemyAI = enemyAI;
    }

    protected override Dictionary<string, State> InitializeStates()
    {
        Dictionary<string, State> enemyAIStates = new Dictionary<string, State> { };
        enemyAIStates.Add(EnemyStateList.IDLE, new EnemyIdle());
        enemyAIStates.Add(EnemyStateList.CHASE, new EnemyChase(enemyAI));
        enemyAIStates.Add(EnemyStateList.PATROL, new EnemyPatrol(enemyAI));

        AddTransition(enemyAIStates[EnemyStateList.IDLE], enemyAIStates[EnemyStateList.PATROL], () => !enemyAI.IsTargetInVision());
        AddTransition(enemyAIStates[EnemyStateList.PATROL], enemyAIStates[EnemyStateList.CHASE], () => enemyAI.IsTargetInVision());
        AddTransition(enemyAIStates[EnemyStateList.CHASE], enemyAIStates[EnemyStateList.PATROL], () => !enemyAI.IsTargetInVision());
        return enemyAIStates;
    }


    public override void OnLogic()
    {
        base.OnLogic();
    }
}
