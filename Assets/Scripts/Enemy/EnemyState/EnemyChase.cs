using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyChase : State
{
    private EnemyStateContext enemyContext;

    public EnemyChase(EnemyStateContext context) : base(context)
    {
        enemyContext = context;
    }

    public override void Enter()
    {

    }

    public override void Exit()
    {
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        Vector3 targetPosition = enemyContext.ChaseTarget.position;
        Vector3 position = enemyContext.transform.position;
        Vector3 targetDirection = (targetPosition - position).normalized;

        //enemyContext.RigidbodyComponent.velocity = targetDirection * enemyContext.EnemyMovementSpeed;

        enemyContext.CharacterController.Move(targetDirection * enemyContext.EnemyMovementSpeed * Time.deltaTime);
        enemyContext.transform.forward = Vector3.Lerp(enemyContext.transform.forward, targetDirection, Time.deltaTime * 3);

       /* if (Physics.Raycast(enemyContext.transform.position, targetDirection, enemyContext.ChaseDistance - 0.1f, enemyContext.LayerMask))
        {
            enemyContext.RigidbodyComponent.velocity = Vector3.zero;
        }*/
    }

    public bool IsTargetInRange()
    {
        Vector3 targetPosition = enemyContext.ChaseTarget.position;
        Vector3 position = enemyContext.transform.position;
        return Vector3.Distance(position, targetPosition) <= enemyContext.ChaseDistance;
    }
}
