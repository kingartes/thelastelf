using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyPatrol : State
{
    private readonly EnemyAI enemyAI;
    private int currentPatrolPointIndex;

    public EnemyPatrol(EnemyAI enemyAI) : base(EnemyStateList.PATROL)
    {
        this.enemyAI = enemyAI;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        currentPatrolPointIndex = 0;
        enemyAI.Animator.SetBool("isWalking", true);
    }

    public override void OnExit()
    {
        enemyAI.Animator.SetBool("isWalking", true);
    }


    public override void OnLogic()
    {
        base.OnLogic();

        if (currentPatrolPointIndex < enemyAI.PatrolPoints.Count)
        {
            Vector3 targetPosition = enemyAI.PatrolPoints[currentPatrolPointIndex].transform.position;
            Vector3 position = enemyAI.transform.position;
            Vector3 targetDirection = (targetPosition - position).normalized;
            targetDirection.y = 0;
            targetPosition.y = position.y;
            if (Vector3.Distance(position, targetPosition) > 0.5)
            {
                enemyAI.CharacterController.Move(targetDirection * enemyAI.EnemyMovementSpeed * Time.deltaTime);
                enemyAI.transform.forward = Vector3.Lerp(enemyAI.transform.forward, targetDirection, Time.deltaTime * 3);
            } else
            {
                currentPatrolPointIndex = ++currentPatrolPointIndex % enemyAI.PatrolPoints.Count;
            }
        }
    }
}

