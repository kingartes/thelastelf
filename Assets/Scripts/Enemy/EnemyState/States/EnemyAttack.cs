using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyAttack : State
{
    private float attackCounter;

    private EnemyAI enemyAI;

    public EnemyAttack(EnemyAI enemyAI) : base(EnemyStateList.ATTACK)
    {
        this.enemyAI = enemyAI;
    }

    public override void OnEnter()
    {
        attackCounter = enemyAI.Weapon.AttackInterval;
    }

    public override void OnLogic()
    {
        base.OnLogic();
        attackCounter -= Time.deltaTime;


       

        if (attackCounter <= 0)
        {
            enemyAI.Animator.SetTrigger("attack");
            enemyAI.Weapon.gameObject.SetActive(true);
            enemyAI.Weapon.Attack(enemyAI.ChaseTarget);
            attackCounter = enemyAI.Weapon.AttackInterval;
        }
    }


}
