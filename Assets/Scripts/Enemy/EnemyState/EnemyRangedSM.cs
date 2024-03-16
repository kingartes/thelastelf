using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class EnemyRangedSM : StateMachine<EnemyAI>
{
    private EnemyAI enemyAI;


    public EnemyRangedSM(EnemyAI enemyAI) : base(EnemyStateList.IDLE)
    {
        this.enemyAI = enemyAI;
    }

    protected override Dictionary<string, State> InitializeStates()
    {
        Dictionary<string, State> enemyAIStates = new Dictionary<string, State> { };
        enemyAIStates.Add(EnemyStateList.IDLE, new EnemyIdle());
        enemyAIStates.Add(EnemyStateList.ATTACK_RANGED, new EnemyRangedAttack(enemyAI));

        AddTransition(enemyAIStates[EnemyStateList.IDLE], enemyAIStates[EnemyStateList.ATTACK], () => enemyAI.IsInAttackRange());
        AddTransition(enemyAIStates[EnemyStateList.ATTACK_RANGED], enemyAIStates[EnemyStateList.IDLE], () => !enemyAI.IsInAttackRange());
        return enemyAIStates;
    }
}
