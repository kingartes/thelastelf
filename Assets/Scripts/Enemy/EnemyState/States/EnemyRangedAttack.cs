using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyRangedAttack : State
{
    private float attackCounter;

    private EnemyAI enemyAI;

    public EnemyRangedAttack(EnemyAI enemyAI) : base(EnemyStateList.ATTACK_RANGED)
    {
        this.enemyAI = enemyAI;
    }

    public override void OnEnter()
    {
        attackCounter = enemyAI.AttackDelay;
    }

    public override void OnLogic()
    {
        base.OnLogic();
        attackCounter -= Time.deltaTime;

        if (attackCounter <= 0)
        {
            enemyAI.Weapon.gameObject.SetActive(true);
            enemyAI.Weapon.Attack(enemyAI.ChaseTarget);
            attackCounter = enemyAI.AttackDelay;
        }
    }


}