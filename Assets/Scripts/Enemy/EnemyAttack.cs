using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttackTest : MonoBehaviour
{
    [SerializeField]
    private float attackDelay = 0.3f;
    [SerializeField]
    private float attackRange = 2f;
    [SerializeField]
    private float attackDamage = 40;
    [SerializeField]
    private LayerMask layerMask;

    private float attackCounter = 0;

    private void Awake()
    {
        attackCounter = attackDelay;
    }

    private void FixedUpdate()
    {
        attackCounter -= Time.deltaTime;

        if (attackCounter <= 0)
        {
            Debug.Log("attack");
            Collider[] collisions = Physics.OverlapSphere(transform.position, attackRange, layerMask);
            Debug.Log(collisions.Length);
            foreach (Collider collision in collisions)
            {
                Debug.Log(collision);
                Debug.Log(collision.gameObject.TryGetComponent<Health>(out Health playerHealth1));
                if (collision.gameObject.TryGetComponent<Health>( out Health playerHealth))
                {
                    playerHealth.TakeDamage(attackDamage);
                    attackCounter = attackDelay;
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Color color = Color.yellow;
        color.a = 0.3f;
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, attackRange);
    }
}
