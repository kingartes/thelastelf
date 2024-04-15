using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyChase : State
{

    private EnemyAI enemyAI;
    public EnemyChase(EnemyAI enemyAI) : base(EnemyStateList.CHASE)
    {
        this.enemyAI = enemyAI;
    }

    public override void OnEnter()
    {
        enemyAI.Animator.SetBool("isWalking", true);
    }

    public override void OnExit()
    {
        enemyAI.Animator.SetBool("isWalking", true);
    }

    public override void OnLogic()
    {
        base.OnLogic();
        Vector3 targetPosition = enemyAI.ChaseTarget.position;
        Vector3 position = enemyAI.transform.position;
        Vector3 targetDirection = (targetPosition - position).normalized;
        targetPosition.y = position.y;

        //enemyContext.RigidbodyComponent.velocity = targetDirection * enemyContext.EnemyMovementSpeed;

        enemyAI.CharacterController.Move(targetDirection * enemyAI.EnemyMovementSpeed * Time.deltaTime);
        enemyAI.transform.forward = Vector3.Lerp(enemyAI.transform.forward, targetDirection, Time.deltaTime * 20);

        /* if (Physics.Raycast(enemyContext.transform.position, targetDirection, enemyContext.ChaseDistance - 0.1f, enemyContext.LayerMask))
         {
             enemyContext.RigidbodyComponent.velocity = Vector3.zero;
         }*/
    }

}

