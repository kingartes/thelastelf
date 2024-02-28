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
        attackCounter = enemyAI.AttackDelay;
    }

    public override void OnLogic()
    {
        base.OnLogic();
        attackCounter -= Time.deltaTime;

        if (attackCounter <= 0)
        {
            /* Debug.Log("attack");
             Collider[] collisions = Physics.OverlapSphere(enemyContext.transform.position, enemyContext.ChaseDistance, enemyContext.LayerMask);
             foreach (Collider collision in collisions)
             {
                 if (collision.gameObject.TryGetComponent<Health>(out Health playerHealth))
                 {
                     playerHealth.TakeDamage(enemyContext.AttackDamage);
                     attackCounter = enemyContext.AttackDelay;
                 }
             }*/
            enemyAI.Weapon.gameObject.SetActive(true);
            enemyAI.Weapon.Attack();
            attackCounter = enemyAI.AttackDelay;
        }
    }


}
