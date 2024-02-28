using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack_Deprecated : State_Deprecated
{

    private EnemyStateContext enemyContext;
    private float attackCounter;

    public EnemyAttack_Deprecated(EnemyStateContext context) : base(context)
    {
        enemyContext = context;
    }

    public override void Enter()
    {
        attackCounter = enemyContext.AttackDelay;
    }

    public override void Exit()
    {
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
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
            enemyContext.Weapon.gameObject.SetActive(true);
            enemyContext.Weapon.Attack();
            attackCounter = enemyContext.AttackDelay;
        }
    }

    public bool IsTargetInRange()
    {
        Vector3 targetPosition = enemyContext.ChaseTarget.position;
        Vector3 position = enemyContext.transform.position;
        return Vector3.Distance(position, targetPosition) <= enemyContext.ChaseDistance;
    }
}
