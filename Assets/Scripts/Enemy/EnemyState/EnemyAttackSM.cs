using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;

public class EnemyAttackSM : StateMachine<EnemyAI>
{
    private EnemyAI enemyAI;


    public EnemyAttackSM(EnemyAI enemyAI) : base(EnemyStateList.IDLE)
    {
        this.enemyAI = enemyAI;
    }

    protected override Dictionary<string, State> InitializeStates()
    {
        Dictionary<string, State> enemyAIStates = new Dictionary<string, State> { };
        enemyAIStates.Add(EnemyStateList.IDLE, new EnemyIdle());
        enemyAIStates.Add(EnemyStateList.ATTACK, new EnemyAttack(enemyAI));

        AddTransition(enemyAIStates[EnemyStateList.IDLE], enemyAIStates[EnemyStateList.ATTACK], () => enemyAI.IsInMeeleAttackRange());
        AddTransition(enemyAIStates[EnemyStateList.ATTACK], enemyAIStates[EnemyStateList.IDLE], () => !enemyAI.IsInMeeleAttackRange());
        return enemyAIStates;
    }
}
